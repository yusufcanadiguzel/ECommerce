using ECommerce.Application.Common.Interfaces;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct;

public sealed class CreateProductHandler : ICommandHandler<CreateProductCommand>
{
    public Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
