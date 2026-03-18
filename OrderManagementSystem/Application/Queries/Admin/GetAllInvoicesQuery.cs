using MediatR;
using OrderManagementSystem.Application.DTOs.Invoice;

public class GetAllInvoicesQuery : IRequest<List<InvoiceResponseDto>>
{
}
