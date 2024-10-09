using Desafio_Desenvolvimento.Domain.Entities;

namespace Desafio_Desenvolvimento.Application.Interfaces.Repositories
{
    public interface IObterProcessoPorIdRepository
    {
        Task<Processo?> ObterProcessoPorIdAsync(Guid id);
    }
}
