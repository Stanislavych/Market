namespace Market.Application.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Domain.Entities.Category>
    {
        Task<bool> ExistByName(string name);
        Task<bool> ExistById(int id);
    }
}
