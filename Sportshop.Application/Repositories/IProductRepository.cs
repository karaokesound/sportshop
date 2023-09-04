namespace Sportshop.Application.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync();

        Task UpdateAsync();

        Task PartiallyUpdateAsync();

        Task DeleteAsync();
    }
}
