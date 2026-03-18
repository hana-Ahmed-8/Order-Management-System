using OrderManagementSystem.Application.DTOs.Invoice;
using OrderManagementSystem.Core.Enums;

namespace OrderManagementSystem.Application.DTOs.Order
{
 
    public class OrderDetailResponseDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Subtotal { get; set; }         
        public decimal DiscountAmount { get; set; }   
        public decimal TotalAmount { get; set; }       
        public PaymentMethod PaymentMethod { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<OrderItemDetailDto> Items { get; set; } = new();
        public InvoiceDto? Invoice { get; set; }
    }
}