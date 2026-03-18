using MediatR;
using OrderManagementSystem.Application.DTOs.Order;
using OrderManagementSystem.Core.Interfaces;

namespace OrderManagementSystem.Application.Queries.Orders
{
  
    public class GetMyOrdersQueryHandler : IRequestHandler<GetMyOrdersQuery, List<OrderResponseDto>>
    {
        private readonly IOrderRepository _orderRepo;

        public GetMyOrdersQueryHandler(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<List<OrderResponseDto>> Handle(
            GetMyOrdersQuery request,
            CancellationToken cancellationToken)
        {
             
            var orders = await _orderRepo.GetByCustomerIdAsync(request.CustomerId);

             
            var result = new List<OrderResponseDto>();
            foreach (var order in orders)
            {
                result.Add(new OrderResponseDto
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    Status = order.Status
                });
            }

            return result;
        }
    }
}