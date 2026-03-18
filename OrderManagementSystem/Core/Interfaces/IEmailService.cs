namespace OrderManagementSystem.Core.Interfaces
{
    public interface IEmailService
    {
        Task SendOrderStatusChangedEmail(string customerEmail, int orderId, string newStatus);
    }
}