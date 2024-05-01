using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Category.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Domain.Entities.Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entities.Category> Handle(GetCategoryByIdQuery request,CancellationToken cancellationToken)
        {
            if (!(await _unitOfWork.Category.ExistById(request.Id)))
            {
                throw new ArgumentException("Category with this Id does not exist.");
            }

            var category = await _unitOfWork.Category.FindByConditionAsync(i=>i.Id == request.Id);
            var currentCategory = category.FirstOrDefault();

            return currentCategory;
        }
    }
}
