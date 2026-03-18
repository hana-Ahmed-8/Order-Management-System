using OrderManagementSystem.Core.Enums;
namespace OrderManagementSystem.Application.DTOs.Order
{
 
    public class CreateOrderDto
    {
        public PaymentMethod PaymentMethod { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }
}