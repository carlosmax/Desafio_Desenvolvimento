namespace Desafio_Desenvolvimento.Core
{ 
    public interface ICommandResult
    {
        bool Success { get; }
        string? Message { get; }
        IList<string> Errors { get; }
        object? Result { get; }
    }
}
