using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Product.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Product.FindByConditionAsync(i => i.Id == request.Id);
            var currentProduct = product.FirstOrDefault();

            _unitOfWork.Product.Delete(currentProduct);

            await _unitOfWork.SaveChangesAsync();

            return currentProduct.Id;
        }
    }
}
