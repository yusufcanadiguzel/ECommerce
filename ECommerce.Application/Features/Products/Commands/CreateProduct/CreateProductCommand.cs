using ECommerce.Application.Common.Interfaces;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand : ICommand
{
    public string Name { get; init; }
}
