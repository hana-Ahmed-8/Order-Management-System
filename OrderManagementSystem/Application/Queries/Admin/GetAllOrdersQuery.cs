using MediatR;
using OrderManagementSystem.Application.DTOs.Order;

namespace OrderManagementSystem.Application.Queries.Orders
{
    public class GetAllOrdersQuery : IRequest<List<OrderResponseDto>>
    {
         
    }
}
