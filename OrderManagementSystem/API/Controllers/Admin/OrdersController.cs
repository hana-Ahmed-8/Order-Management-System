using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.Commands.Admin;
using OrderManagementSystem.Application.DTOs.Order.Admin;
using OrderManagementSystem.Application.Queries.Admin;
using OrderManagementSystem.Application.Queries.Orders;

namespace OrderManagementSystem.API.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/admin/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(result);
        }

        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(
            int orderId,
            [FromBody] UpdateOrderStatusDto dto)
        {
            var command = new UpdateOrderStatusCommand(orderId, dto.Status);
            var success = await _mediator.Send(command);

            if (!success)
                return NotFound("Order not found");

            return Ok("Order status updated");
        }
    }
}
