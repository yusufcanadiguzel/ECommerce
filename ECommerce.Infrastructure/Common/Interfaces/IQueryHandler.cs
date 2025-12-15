namespace ECommerce.Infrastructure.Common.Interfaces;

public interface IQueryHandler<TQuery, TResult>
{
    Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
}
