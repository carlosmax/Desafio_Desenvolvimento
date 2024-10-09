using Desafio_Desenvolvimento.Application.ViewModel;
using Desafio_Desenvolvimento.Core;

namespace Desafio_Desenvolvimento.Application.Queries
{
    public class ObterProcessosQuery : IQuery<PaginatedList<ProcessoViewModel>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
