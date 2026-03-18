using OrderManagementSystem.Core.Entities;

namespace OrderManagementSystem.Core.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllAsync();

        Task<Invoice> CreateAsync(Invoice invoice);
        Task<Invoice?> GetByOrderIdAsync(int orderId);
    }
}