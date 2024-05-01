using MediatR;

namespace Market.Application.Product.Commands
{
    public class UpdateProductCommand : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
