using OrderManagementSystem.Application.DTOs.Invoice;
using OrderManagementSystem.Application.DTOs.Order;
using OrderManagementSystem.Core.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace OrderManagementSystem.Application.DTOs.Invoice
{
    
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
