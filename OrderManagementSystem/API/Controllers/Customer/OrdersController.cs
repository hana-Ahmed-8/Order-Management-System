using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.Commands.Customer;
using OrderManagementSystem.Application.DTOs.Order;
using OrderManagementSystem.Application.Queries.Orders;
using OrderManagementSystem.Core.Entities;

namespace OrderManagementSystem.API.Controllers.Customer
{
    [Authorize(Roles = "Customer")]
    [ApiController]
    [Route("api/customer/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(
            IMediator mediator,
            UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

 
        [HttpGet]
        public async Task<IActionResult> GetMyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User not found");

            var query = new GetMyOrdersQuery(user.Id);
            var orders = await _mediator.Send(query);

            return Ok(orders);
        }

 
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetMyOrder(int orderId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var query = new GetMyOrderByIdQuery(orderId, user.Id);
            var order = await _mediator.Send(query);

            if (order == null)
                return Forbid();

            return Ok(order);
        }
 
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var command = new CreateOrderCommand(user.Id, dto);
            var result = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetMyOrder),
                new { orderId = result.OrderId },
                result
            );
        }
    }
}
