using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Product.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Domain.Entities.Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            if (!(await _unitOfWork.Product.ExistById(request.Id)))
            {
                throw new ArgumentException("Product with this Id does not exist.");
            }

            var product = await _unitOfWork.Product.FindByConditionAsync(i => i.Id == request.Id);
            var currentProduct = product.FirstOrDefault();

            return currentProduct;
        }
    }
}
