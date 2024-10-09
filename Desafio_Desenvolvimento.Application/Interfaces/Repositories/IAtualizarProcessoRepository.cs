using Desafio_Desenvolvimento.Domain.Entities;

namespace Desafio_Desenvolvimento.Application.Interfaces.Repositories
{
    public interface IAtualizarProcessoRepository
    {
        Task AtualizarProcessoAsync(Processo processo);
    }
}
