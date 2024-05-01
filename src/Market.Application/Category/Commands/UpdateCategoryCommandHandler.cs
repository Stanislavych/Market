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
