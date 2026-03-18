using OrderManagementSystem.Core.Entities;

namespace OrderManagementSystem.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);

       
        Task<List<Order>> GetByCustomerIdAsync(string customerId);
        Task<Order?> GetByIdAndCustomerIdAsync(int orderId, string customerId);
        Task<Order?> GetOrderWithDetailsAsync(int orderId, string customerId);

         
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int orderId);
        Task UpdateAsync(Order order);

        Task<Order?> GetByIdWithCustomerAsync(int orderId);
    }
}