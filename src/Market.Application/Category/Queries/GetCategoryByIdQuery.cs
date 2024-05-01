using MediatR;

namespace Market.Application.Category.Queries
{
    public class GetCategoryByIdQuery : IRequest<Domain.Entities.Category>
    {
        public int Id { get; set; }
    }
}
