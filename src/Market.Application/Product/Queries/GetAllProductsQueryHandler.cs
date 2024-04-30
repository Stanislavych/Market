using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Product.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Domain.Entities.Product>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductsQuery request,CancellationToken cancellationToken)
        {
            return await _unitOfWork.Product.FindAllAsync();
        }
    }
}
