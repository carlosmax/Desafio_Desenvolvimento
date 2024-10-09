namespace Desafio_Desenvolvimento.Core
{ 
    public interface ICommandValidationResult
    {
        bool Success { get; }
        IList<string> Errors { get; }
    }
}
