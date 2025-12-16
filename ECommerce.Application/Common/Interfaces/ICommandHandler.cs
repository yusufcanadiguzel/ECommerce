namespace ECommerce.Application.Common.Interfaces;

public interface ICommandHandler<TCommand, TResult>
{
    Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
}
