using MediatR;

namespace Market.Application.Product.Queries
{
    public class GetProductsByCategoryNameQuery : IRequest<IEnumerable<Domain.Entities.Product>>
    {
        public string CategoryName { get; set; }
    }
}
