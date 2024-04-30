using MediatR;

namespace Market.Application.Category.Commands
{
    public class AddCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
