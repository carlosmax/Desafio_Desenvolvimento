using Desafio_Desenvolvimento.Application.Commands;
using Desafio_Desenvolvimento.Application.Interfaces.Repositories;
using Desafio_Desenvolvimento.Core;
using Desafio_Desenvolvimento.Domain.Entities;

namespace Desafio_Desenvolvimento.Application.Handlers
{
    public class CadastrarProcessoHandler : IHandler<CadastrarProcessoCommand>
    {
        private readonly ICriarProcessoRepository _criarProcessoRepository;
        private readonly IObterProcessoPorNpuRepository _obterProcessoPorNpuRepository;

        public CadastrarProcessoHandler(ICriarProcessoRepository criarProcessoRepository, IObterProcessoPorNpuRepository obterProcessoPorNpuRepository)
        {
            _criarProcessoRepository = criarProcessoRepository;
            _obterProcessoPorNpuRepository = obterProcessoPorNpuRepository;
        }

        public async Task<ICommandResult> HandleAsync(CadastrarProcessoCommand command)
        {
            // Fast fail validation
            var result = command.Validate();

            if (!result.Success)
                return CommandResult.FailResult(result.Errors);

            var processoExistente = await _obterProcessoPorNpuRepository.ObterProcessoPorNpuAsync(command.Npu);

            if (processoExistente != null)
                return CommandResult.FailResult("Já existe um processo com o NPU informado.");

            var processo = new Processo(command.Nome, command.Npu, command.Uf, command.Municipio, command.MunicipioCodigo);
            var processoCriado = await _criarProcessoRepository.CriarProcessoAsync(processo);

            return CommandResult.SuccessResult("Processo criado com sucesso!");
        }
    }
}
