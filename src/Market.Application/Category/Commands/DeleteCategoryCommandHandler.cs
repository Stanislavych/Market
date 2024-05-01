using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Category.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!(await _unitOfWork.Category.ExistById(request.Id)))
            {
                throw new ArgumentException("Category with this Id does not exist.");
            }

            var category = await _unitOfWork.Category.FindByConditionAsync(i=>i.Id== request.Id);
            var currentCategory = category.FirstOrDefault();

            _unitOfWork.Category.Delete(currentCategory);
            
            await _unitOfWork.SaveChangesAsync();

            return currentCategory.Id;
        }
    }
}
