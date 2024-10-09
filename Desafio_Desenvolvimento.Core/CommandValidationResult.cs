
namespace Desafio_Desenvolvimento.Core
{
    public class CommandValidationResult : ICommandValidationResult
    {
        private readonly IList<string> _errors;

        public CommandValidationResult() 
        {
            _errors = new List<string>();
        }

        public bool Success => !Errors.Any();

        public IList<string> Errors => _errors;
    }
}
