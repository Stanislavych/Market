using Market.Application.Repositories;
using MediatR;

namespace Market.Application.Product.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Domain.Entities.Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entities.Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentException("Name is required.");
            }

            if (request.Price == null || request.Price < 0)
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

            if (!(await _unitOfWork.Product.ExistById(request.Id)))
            {
                throw new ArgumentException("Product with this Id does not exist.");
            }

            var product = new Domain.Entities.Product
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId
            };

            _unitOfWork.Product.Update(product);

            await _unitOfWork.SaveChangesAsync();

            return product;
        }
    }
}
