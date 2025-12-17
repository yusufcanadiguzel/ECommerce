using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.DTOs.Product;

namespace ECommerce.Application.Features.Products.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdDto>
{
    public Task<GetProductByIdDto> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        return Task.FromResult<GetProductByIdDto>(null);
    }
}
