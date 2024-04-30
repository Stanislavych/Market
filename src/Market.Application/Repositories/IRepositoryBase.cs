using System.Linq.Expressions;

namespace Market.Application.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
