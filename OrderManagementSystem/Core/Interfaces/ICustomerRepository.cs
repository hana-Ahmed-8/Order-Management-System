using OrderManagementSystem.Core.Entities;

namespace OrderManagementSystem.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
    }
}
