using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.Queries.Admin;

namespace OrderManagementSystem.API.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/admin/invoices")]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var result = await _mediator.Send(new GetAllInvoicesQuery());
            return Ok(result);
        }
        [HttpGet("/admin/{orderId}")]
        public async Task<IActionResult> GetInvoiceByOrderId(int orderId)
        {
            var result = await _mediator.Send(new GetInvoiceByOrderIdQuery(orderId));

            if (result == null)
                return NotFound("Invoice not found");

            return Ok(result);
        }

    }

}
