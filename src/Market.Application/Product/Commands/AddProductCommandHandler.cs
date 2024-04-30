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

        public async Task<int> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product
            {
                Name = command.Name,
                Price = command.Price,
                CategoryId = command.CategoryId
            };

            await _unitOfWork.Product.CreateAsync(product);

            return product.Id;
        }
    }
}
