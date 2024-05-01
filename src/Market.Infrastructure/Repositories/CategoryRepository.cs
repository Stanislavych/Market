using Market.Application.Repositories;
using Market.Domain.Entities;
using Market.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<bool> ExistByName(string name)
        {
            return await context.Set<Category>().AnyAsync(c => c.Name == name);
        }

        public async Task<bool> ExistById(int id)
        {
            return await context.Set<Category>().AnyAsync(c => c.Id == id);
        }
    }
}
