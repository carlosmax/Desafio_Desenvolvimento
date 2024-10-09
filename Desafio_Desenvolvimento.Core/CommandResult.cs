
namespace Desafio_Desenvolvimento.Core
{
    public class CommandResult : ICommandResult
    {
        private readonly IList<string> _errors;

        public CommandResult(bool success, string? message, IList<string> errors)
        {
            Success = success;
            Message = message;
            _errors = errors;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Result { get; set; }
        public IList<string> Errors => _errors;

        public static CommandResult SuccessResult(string message)
        {
            return new CommandResult(true, message, []);
        }

        public static CommandResult FailResult(string message)
        {
            return new CommandResult(false, message, []);
        }

        public static CommandResult FailResult(IList<string> errors)
        {
            return new CommandResult(false, String.Empty, errors ?? []);
        }

        public static CommandResult FailResult(string message, IList<string> errors)
        {
            return new CommandResult(false, message, errors ?? []);
        }
    }
}
