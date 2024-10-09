using Desafio_Desenvolvimento.Domain.Entities;

namespace Desafio_Desenvolvimento.Application.Interfaces.Repositories
{
    public interface IObterProcessoPorNpuRepository
    {
        Task<Processo?> ObterProcessoPorNpuAsync(string npu);
    }
}
