namespace Market.Application.Repositories
{
    public interface IProductRepository : IRepositoryBase<Domain.Entities.Product>
    {
        Task<IEnumerable<Domain.Entities.Product>> FindByCategoryNameAsync(string categoryName);
        Task<bool> ExistByName(string name);
        Task<bool> ExistById(int id);
    }
}
