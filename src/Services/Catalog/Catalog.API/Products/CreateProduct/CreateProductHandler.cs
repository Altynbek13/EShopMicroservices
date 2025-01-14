using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category,string Description,string ImagePath,decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImagePath = command.ImagePath,
                Price = command.Price,
            };
            return new CreateProductResult(Guid.NewGuid());

        }
    }
}
