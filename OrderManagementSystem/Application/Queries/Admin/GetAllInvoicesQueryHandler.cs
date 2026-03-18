using MediatR;
using OrderManagementSystem.Application.DTOs.Invoice;
using OrderManagementSystem.Core.Interfaces;

public class GetAllInvoicesQueryHandler
    : IRequestHandler<GetAllInvoicesQuery, List<InvoiceResponseDto>>
{
    private readonly IInvoiceRepository _invoiceRepo;

    public GetAllInvoicesQueryHandler(IInvoiceRepository invoiceRepo)
    {
        _invoiceRepo = invoiceRepo;
    }

    public async Task<List<InvoiceResponseDto>> Handle(
        GetAllInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        var invoices = await _invoiceRepo.GetAllAsync();

        return invoices.Select(i => new InvoiceResponseDto
        {
            InvoiceId = i.InvoiceId,
            OrderId = i.OrderId,
            InvoiceDate = i.InvoiceDate,
            TotalAmount = i.TotalAmount
        }).ToList();
    }
}
