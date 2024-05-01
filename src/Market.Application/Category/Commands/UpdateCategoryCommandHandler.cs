using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Category.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Domain.Entities.Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entities.Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentException("Name is required.");
            }

            if (await _unitOfWork.Category.ExistByName(request.Name))
            {
                throw new ArgumentException("Category with the same name already exist.");
            }

            if (!(await _unitOfWork.Category.ExistById(request.Id)))
            {
                throw new ArgumentException("Category with this Id does not exist.");
            }

            var category = new Domain.Entities.Category 
            {
                Id = request.Id,
                Name = request.Name
            };

            _unitOfWork.Category.Update(category);

            await _unitOfWork.SaveChangesAsync();

            return category;
        }
    }
}
