using Desafio_Desenvolvimento.Application.ViewModel;
using Desafio_Desenvolvimento.Core;

namespace Desafio_Desenvolvimento.Application.Queries
{
    public class ObterProcessoPorIdQuery : IQuery<ProcessoViewModel?>
    {
        public Guid Id { get; set; }
    }
}
