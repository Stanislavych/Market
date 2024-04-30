using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Category.Queries
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Domain.Entities.Category>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Domain.Entities.Category>> Handle(GetAllCategoriesQuery request,CancellationToken cancellationToken)
        {
            return await _unitOfWork.Category.FindAllAsync();
        }
    }
}
