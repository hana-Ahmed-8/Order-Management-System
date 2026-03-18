using OrderManagementSystem.Core.Enums;
namespace OrderManagementSystem.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public string CustomerId { get; set; } = null!;
        public Customer? Customer { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }


        public string Status { get; set; } = "Pending";

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
