namespace Desafio_Desenvolvimento.Core
{
    public interface ICommand
    {
        ICommandValidationResult Validate();
    }
}
