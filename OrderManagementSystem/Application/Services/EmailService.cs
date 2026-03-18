using OrderManagementSystem.Core.Interfaces;

namespace OrderManagementSystem.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public Task SendOrderStatusChangedEmail(string customerEmail, int orderId, string newStatus)
        {
    
            Console.WriteLine($" EMAIL: Sent to {customerEmail} - Order #{orderId} is now '{newStatus}'");
            return Task.CompletedTask;
        }
    }
}