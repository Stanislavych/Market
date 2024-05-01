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
