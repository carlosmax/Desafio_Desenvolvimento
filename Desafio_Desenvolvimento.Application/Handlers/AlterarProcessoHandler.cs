using Desafio_Desenvolvimento.Application.Commands;
using Desafio_Desenvolvimento.Application.Interfaces.Repositories;
using Desafio_Desenvolvimento.Core;

namespace Desafio_Desenvolvimento.Application.Handlers
{
    public class AlterarProcessoHandler : IHandler<AlterarProcessoCommand>
    {
        private readonly IAtualizarProcessoRepository _atualizarProcessoRepository;
        private readonly IObterProcessoPorIdRepository _obterProcessoPorIdRepository;
        private readonly IObterProcessoPorNpuRepository _obterProcessoPorNpuRepository;

        public AlterarProcessoHandler(IAtualizarProcessoRepository atualizarProcessoRepository, IObterProcessoPorIdRepository obterProcessoPorIdRepository, IObterProcessoPorNpuRepository obterProcessoPorNpuRepository)
        {
            _atualizarProcessoRepository = atualizarProcessoRepository;
            _obterProcessoPorIdRepository = obterProcessoPorIdRepository;
            _obterProcessoPorNpuRepository = obterProcessoPorNpuRepository;
        }

        public async Task<ICommandResult> HandleAsync(AlterarProcessoCommand command)
        {
            // Fast fail validation
            var result = command.Validate();

            if (!result.Success)
                return CommandResult.FailResult(result.Errors);

            var processo = await _obterProcessoPorIdRepository.ObterProcessoPorIdAsync(command.Id);

            if (processo == null) 
                return CommandResult.FailResult("Processo não encontrado");

            var processoExistente = await _obterProcessoPorNpuRepository.ObterProcessoPorNpuAsync(command.Npu);

            if (processoExistente != null)
                return CommandResult.FailResult("Já existe um processo com o NPU informado.");

            processo.Atualizar(command.Nome, command.Npu, command.Uf, command.Municipio, command.MunicipioCodigo);

            await _atualizarProcessoRepository.AtualizarProcessoAsync(processo);

            return CommandResult.SuccessResult("Processo atualizado com sucesso!");
        }
    }
}
