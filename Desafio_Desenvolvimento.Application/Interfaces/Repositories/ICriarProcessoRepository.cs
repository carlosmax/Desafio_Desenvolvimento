using Desafio_Desenvolvimento.Domain.Entities;

namespace Desafio_Desenvolvimento.Application.Interfaces.Repositories
{
    public interface ICriarProcessoRepository
    {
        Task<Processo> CriarProcessoAsync(Processo processo);
    }
}
