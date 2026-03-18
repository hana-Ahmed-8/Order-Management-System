
using MediatR;
using OrderManagementSystem.Core.Interfaces;

namespace OrderManagementSystem.Application.Commands.Admin
{
    public class UpdateOrderStatusCommandHandler
        : IRequestHandler<UpdateOrderStatusCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailService _emailService;

        public UpdateOrderStatusCommandHandler(
            IOrderRepository orderRepository,
            IEmailService emailService)
        {
            _orderRepository = orderRepository;
            _emailService = emailService;
        }

        public async Task<bool> Handle(
            UpdateOrderStatusCommand request,
            CancellationToken cancellationToken)
        {
 
            var order = await _orderRepository.GetByIdWithCustomerAsync(request.OrderId);

 
            if (order?.Customer?.ApplicationUser?.Email == null)
                return false;

            
            order.Status = request.Status;
            await _orderRepository.UpdateAsync(order);

           
            await _emailService.SendOrderStatusChangedEmail(
                order.Customer.ApplicationUser.Email,
                order.OrderId,
                order.Status
            );

            return true;
        }
    }
}