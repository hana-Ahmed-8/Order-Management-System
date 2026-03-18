using MediatR;
using OrderManagementSystem.Application.DTOs.Order;

namespace OrderManagementSystem.Application.Queries.Orders
{
  
    public class GetMyOrdersQuery : IRequest<List<OrderResponseDto>>
    {
        public string CustomerId { get; set; }

        public GetMyOrdersQuery(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
    
