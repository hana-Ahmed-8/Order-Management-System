using MediatR;

namespace OrderManagementSystem.Application.Commands.Admin
{
    public class UpdateOrderStatusCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public string Status { get; set; }

        public UpdateOrderStatusCommand(int orderId, string status)
        {
            OrderId = orderId;
            Status = status;
        }
    }
}
