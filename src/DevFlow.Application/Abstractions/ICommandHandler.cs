namespace DevFlow.Application.Abstractions;

public interface ICommandHandler<in TCommand, out TResult>
{
    TResult Handle(TCommand command);
}