using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Category.Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand,int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Domain.Entities.Category
            {
                Name = request.Name
            };

            await _unitOfWork.Category.CreateAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return category.Id;
        }
    }
}
