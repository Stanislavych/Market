using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Product.Queries
{
    public class GetProductsByCategoryNameQueryHandler : IRequestHandler<GetProductsByCategoryNameQuery, IEnumerable<Domain.Entities.Product>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductsByCategoryNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetProductsByCategoryNameQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Product.FindByCategoryNameAsync(request.CategoryName);
        }
    }
}
