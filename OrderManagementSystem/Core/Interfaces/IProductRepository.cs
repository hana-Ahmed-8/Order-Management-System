using OrderManagementSystem.Core.Entities;

namespace OrderManagementSystem.Core.Interfaces
{
    public interface IProductRepository
    {

        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<List<Product>> GetByIdsAsync(List<int> productIds);
    }
}
