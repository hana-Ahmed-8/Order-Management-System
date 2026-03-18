using MediatR;
using OrderManagementSystem.Application.DTOs.Invoice;
using OrderManagementSystem.Application.DTOs.Order;
using OrderManagementSystem.Core.Interfaces;

namespace OrderManagementSystem.Application.Queries.Orders
{
    
    public class GetMyOrderByIdQueryHandler : IRequestHandler<GetMyOrderByIdQuery, OrderDetailResponseDto?>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IInvoiceRepository _invoiceRepo;

        public GetMyOrderByIdQueryHandler(
            IOrderRepository orderRepo,
            IInvoiceRepository invoiceRepo)
        {
            _orderRepo = orderRepo;
            _invoiceRepo = invoiceRepo;
        }

        public async Task<OrderDetailResponseDto?> Handle(
            GetMyOrderByIdQuery request,
            CancellationToken cancellationToken)
        {
             
            var order = await _orderRepo.GetOrderWithDetailsAsync(request.OrderId, request.CustomerId);

            if (order == null)
                return null;
 
            var invoice = await _invoiceRepo.GetByOrderIdAsync(order.OrderId);

       
            decimal subtotal = 0;
            foreach (var item in order.OrderItems)
            {
                subtotal += item.UnitPrice * item.Quantity;
            }

           
            decimal discountAmount = subtotal - order.TotalAmount;

       
            var response = new OrderDetailResponseDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                Subtotal = subtotal,
                DiscountAmount = discountAmount,
                TotalAmount = order.TotalAmount,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status,
                Items = new List<OrderItemDetailDto>()
            };

            // STEP 6: Add items
            foreach (var item in order.OrderItems)
            {
                response.Items.Add(new OrderItemDetailDto
                {
                    ProductId = item.ProductId,
                    ProductName = item.Product?.Name ?? "Unknown",
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Subtotal = item.UnitPrice * item.Quantity
                });
            }

            
            if (invoice != null)
            {
                response.Invoice = new InvoiceDto
                {
                    InvoiceId = invoice.InvoiceId,
                    InvoiceDate = invoice.InvoiceDate,
                    TotalAmount = invoice.TotalAmount
                };
            }

            return response;
        }
    }
}