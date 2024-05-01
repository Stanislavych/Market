using MediatR;

namespace Market.Application.Product.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
