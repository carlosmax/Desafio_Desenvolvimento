namespace Desafio_Desenvolvimento.Core
{ 
    public interface IHandler<TCommand> where TCommand : ICommand
    {
        Task<ICommandResult> HandleAsync(TCommand command);
    }
}
