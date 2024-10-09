using Desafio_Desenvolvimento.Core;

namespace Desafio_Desenvolvimento.Application.Commands
{
    public class ExcluirProcessoCommand : ICommand
    {
        public Guid Id { get; set; }

        public ICommandValidationResult Validate()
        {
            return new CommandValidationResult();
        }
    }
}
