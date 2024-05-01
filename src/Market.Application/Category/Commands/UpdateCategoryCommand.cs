using MediatR;

namespace Market.Application.Category.Commands
{
    public class UpdateCategoryCommand : IRequest<Domain.Entities.Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
