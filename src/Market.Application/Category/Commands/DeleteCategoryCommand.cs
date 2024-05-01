using MediatR;

namespace Market.Application.Category.Commands
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
