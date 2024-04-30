using MediatR;

namespace Market.Application.Product.Commands
{
    public class AddProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
