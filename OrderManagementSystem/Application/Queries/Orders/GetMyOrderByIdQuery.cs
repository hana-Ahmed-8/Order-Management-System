using MediatR;
using OrderManagementSystem.Application.DTOs.Order;

namespace OrderManagementSystem.Application.Queries.Orders
{ 
    public class GetMyOrderByIdQuery : IRequest<OrderDetailResponseDto?>
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }

        public GetMyOrderByIdQuery(int orderId, string customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }
    }
}