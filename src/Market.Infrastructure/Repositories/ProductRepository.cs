using Market.Application.Repositories;
using Market.Domain.Entities;
using Market.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
                
        }

        public async Task<IEnumerable<Product>> FindByCategoryNameAsync(string categoryName)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);

            if (category == null)
            {
                return new List<Product>();
            }

            return await FindByConditionAsync(p=>p.CategoryId == category.Id);
        }

        public async Task<bool> ExistByName(string name)
        {
            return await context.Set<Product>().AnyAsync(p => p.Name == name);
        }
        
        public async Task<bool> ExistById(int id)
        {
            return await context.Set<Product>().AnyAsync(p => p.Id == id);
        }
    }
}
