using MediatR;

namespace Market.Application.Product.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Domain.Entities.Product>>
    {
    }
}
