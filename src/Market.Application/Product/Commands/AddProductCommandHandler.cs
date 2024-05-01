using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Product.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentException("Name is required.");
            }

            if (request.Price==null || request.Price<0)
            {
                throw new ArgumentException("Price is required and must be a positive value.");
            }

            if (await _unitOfWork.Product.ExistByName(request.Name))
            {
                throw new ArgumentException("Product with the same name already exist.");
            }

            if (!(await _unitOfWork.Category.ExistById(request.CategoryId)))
            {
                throw new ArgumentException("Category with this Id does not exist.");
            }

            var product = new Domain.Entities.Product
            {
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId
            };

            await _unitOfWork.Product.CreateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return product.Id;
        }
    }
}
