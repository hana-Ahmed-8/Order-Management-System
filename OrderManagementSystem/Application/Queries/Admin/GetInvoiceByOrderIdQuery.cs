using MediatR;
using OrderManagementSystem.Application.DTOs.Invoice;

namespace OrderManagementSystem.Application.Queries.Admin
{
    public class GetInvoiceByOrderIdQuery : IRequest<InvoiceDto?>
    {
        public int OrderId { get; set; }

        public GetInvoiceByOrderIdQuery(int orderId)
        {
            OrderId = orderId;
        }
    }
}
