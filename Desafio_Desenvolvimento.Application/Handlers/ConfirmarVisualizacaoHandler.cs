using Desafio_Desenvolvimento.Application.Commands;
using Desafio_Desenvolvimento.Application.Interfaces.Repositories;
using Desafio_Desenvolvimento.Core;

namespace Desafio_Desenvolvimento.Application.Handlers
{
    public class ConfirmarVisualizacaoHandler : IHandler<ConfirmarVisualizacaoCommand>
    {
        private readonly IAtualizarProcessoRepository _atualizarProcessoRepository;
        private readonly IObterProcessoPorIdRepository _obterProcessoPorIdRepository;

        public ConfirmarVisualizacaoHandler(IAtualizarProcessoRepository atualizarProcessoRepository, IObterProcessoPorIdRepository obterProcessoPorIdRepository)
        {
            _atualizarProcessoRepository = atualizarProcessoRepository;
            _obterProcessoPorIdRepository = obterProcessoPorIdRepository;
        }

        public async Task<ICommandResult> HandleAsync(ConfirmarVisualizacaoCommand command)
        {
            // Fast fail validation
            var result = command.Validate();

            if (!result.Success)
                return CommandResult.FailResult(result.Errors);

            var processo = await _obterProcessoPorIdRepository.ObterProcessoPorIdAsync(command.Id);

            if (processo == null) 
                return CommandResult.FailResult("Processo não encontrado");

            processo.ConfirmarVisualizacao();
            await _atualizarProcessoRepository.AtualizarProcessoAsync(processo);

            return CommandResult.SuccessResult("Visualização confirmada com sucesso!");
        }
    }
}
