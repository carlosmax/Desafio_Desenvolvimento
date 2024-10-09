using Desafio_Desenvolvimento.Application.Commands;
using Desafio_Desenvolvimento.Application.Interfaces.Repositories;
using Desafio_Desenvolvimento.Core;

namespace Desafio_Desenvolvimento.Application.Handlers
{
    public class ExcluirProcessoHandler : IHandler<ExcluirProcessoCommand>
    {
        private readonly IExcluirProcessoRepository _excluirProcessoRepository;
        private readonly IObterProcessoPorIdRepository _obterProcessoPorIdRepository;

        public ExcluirProcessoHandler(IExcluirProcessoRepository excluirProcessoRepository, IObterProcessoPorIdRepository obterProcessoPorIdRepository)
        {
            _excluirProcessoRepository = excluirProcessoRepository;
            _obterProcessoPorIdRepository = obterProcessoPorIdRepository;
        }

        public async Task<ICommandResult> HandleAsync(ExcluirProcessoCommand command)
        {
            // Fast fail validation
            var result = command.Validate();

            if (!result.Success)
                return CommandResult.FailResult(result.Errors);

            var processo = await _obterProcessoPorIdRepository.ObterProcessoPorIdAsync(command.Id);

            if (processo == null) 
                return CommandResult.FailResult("Processo não encontrado");

            await _excluirProcessoRepository.ExcluirProcessoAsync(processo);

            return CommandResult.SuccessResult("Processo excluído com sucesso!");
        }
    }
}
