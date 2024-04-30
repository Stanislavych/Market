using MediatR;

namespace Market.Application.Category.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Domain.Entities.Category>>
    {
    }
}
