using MediatR;
using OrderManagementSystem.Application.DTOs.Order;

namespace OrderManagementSystem.Application.Commands.Customer
{
    public class CreateOrderCommand : IRequest<OrderDetailResponseDto>
    {
        public string CustomerId { get; set; }
        public CreateOrderDto Dto { get; set; }

        public CreateOrderCommand(string customerId, CreateOrderDto dto)
        {
            CustomerId = customerId;
            Dto = dto;
        }
    }
}