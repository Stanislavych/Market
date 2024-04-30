namespace Market.Application.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        Task SaveChangesAsync();
    }
}
