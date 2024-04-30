using Market.Application.Repositories;
using Market.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Market.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        internal ApplicationDbContext context;
        internal DbSet<T> dbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(dbSet.AsNoTracking().Where(expression));
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await dbSet.ToListAsync();
        }
    }
}
