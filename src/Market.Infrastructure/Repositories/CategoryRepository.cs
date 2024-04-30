using Market.Application.Repositories;
using Market.Domain.Entities;
using Market.Infrastructure.Data;

namespace Market.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
