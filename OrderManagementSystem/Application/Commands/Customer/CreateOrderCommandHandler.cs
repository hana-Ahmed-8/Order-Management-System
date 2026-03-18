using MediatR;
using OrderManagementSystem.Application.DTOs.Order;
using OrderManagementSystem.Application.Services;
using OrderManagementSystem.Core.Entities;
using OrderManagementSystem.Core.Interfaces;
using OrderManagementSystem.Core.Enums;

namespace OrderManagementSystem.Application.Commands.Customer
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDetailResponseDto>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly DiscountService _discountService;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepo,
            IProductRepository productRepo,
            IInvoiceRepository invoiceRepo,
            DiscountService discountService)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _invoiceRepo = invoiceRepo;
            _discountService = discountService;
        }

        public async Task<OrderDetailResponseDto> Handle(CreateOrderCommand request, CancellationToken ct)
        {
          
            var productIds = request.Dto.Items.Select(i => i.ProductId).ToList();
            var products = await _productRepo.GetByIdsAsync(productIds);

            
            if (products.Count != productIds.Count)
                throw new Exception("One or more products not found");
 
            decimal subtotal = 0;
            var orderItems = new List<OrderItem>();

            foreach (var item in request.Dto.Items)
            {
                var product = products.First(p => p.ProductId == item.ProductId);
                if (product.Stock < item.Quantity)
                    throw new Exception($"Not enough stock for {product.Name}");

                orderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                });

                subtotal += product.Price * item.Quantity;
            }
 
            var discount = _discountService.CalculateDiscount(subtotal);
            var total = subtotal - discount;
 
            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = total,
                PaymentMethod = request.Dto.PaymentMethod,
                Status = "Pending",
                OrderItems = orderItems
            };

            var savedOrder = await _orderRepo.CreateAsync(order);

          
            foreach (var item in request.Dto.Items)
            {
                var product = products.First(p => p.ProductId == item.ProductId);
                product.Stock -= item.Quantity;
                await _productRepo.UpdateAsync(product);
            }

            
            var invoice = new Invoice
            {
                OrderId = savedOrder.OrderId,
                InvoiceDate = DateTime.UtcNow,
                TotalAmount = total
            };
            var savedInvoice = await _invoiceRepo.CreateAsync(invoice);

             
            return new OrderDetailResponseDto
            {
                OrderId = savedOrder.OrderId,
                OrderDate = savedOrder.OrderDate,
                Subtotal = subtotal,
                DiscountAmount = discount,
                TotalAmount = total,
                PaymentMethod = request.Dto.PaymentMethod,

                Status = savedOrder.Status,
                Items = orderItems.Select(oi => new OrderItemDetailDto
                {
                    ProductId = oi.ProductId,
                    ProductName = products.First(p => p.ProductId == oi.ProductId).Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    Subtotal = oi.UnitPrice * oi.Quantity
                }).ToList(),
                Invoice = new Application.DTOs.Invoice.InvoiceDto
                {
                    InvoiceId = savedInvoice.InvoiceId,
                    InvoiceDate = savedInvoice.InvoiceDate,
                    TotalAmount = savedInvoice.TotalAmount
                }
            };
        }
    }
}