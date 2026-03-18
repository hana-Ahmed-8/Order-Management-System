using MediatR;
using OrderManagementSystem.Application.DTOs.Order;
using OrderManagementSystem.Core.Interfaces;
using OrderManagementSystem.Application.Queries.Orders;
public class GetAllOrdersQueryHandler
    : IRequestHandler<GetAllOrdersQuery, List<OrderResponseDto>>
{
    private readonly IOrderRepository _orderRepo;

    public GetAllOrdersQueryHandler(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<List<OrderResponseDto>> Handle(
        GetAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var orders = await _orderRepo.GetAllAsync();

        return orders.Select(o => new OrderResponseDto
        {
            OrderId = o.OrderId,
            OrderDate = o.OrderDate,
            TotalAmount = o.TotalAmount,
            Status = o.Status
        }).ToList();
    }
}
