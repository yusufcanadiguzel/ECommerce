using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.DTOs.Product;

namespace ECommerce.Application.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery : IQuery<GetProductByIdDto>
{
    public Guid Id { get; init; }
}
