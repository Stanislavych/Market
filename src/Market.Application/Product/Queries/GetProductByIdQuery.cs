using MediatR;

namespace Market.Application.Product.Queries
{
    public class GetProductByIdQuery : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }
    }
}
