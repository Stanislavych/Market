using Market.Application.Repositories;
using Market.Domain.Entities;
using Market.Infrastructure.Data;

namespace Market.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
                
        }
    }
}
