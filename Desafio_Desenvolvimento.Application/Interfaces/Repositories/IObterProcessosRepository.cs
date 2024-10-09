using Desafio_Desenvolvimento.Domain.Entities;
using Desafio_Desenvolvimento.Core;

namespace Desafio_Desenvolvimento.Application.Interfaces.Repositories
{
    public interface IObterProcessosRepository
    {
        Task<PaginatedList<Processo>> ObterProcessosAsync(int pageNumber, int pageSize);
    }
}
