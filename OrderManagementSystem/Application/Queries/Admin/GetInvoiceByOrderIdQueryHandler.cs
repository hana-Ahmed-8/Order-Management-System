using MediatR;
using OrderManagementSystem.Application.DTOs.Invoice;
using OrderManagementSystem.Core.Interfaces;

namespace OrderManagementSystem.Application.Queries.Admin
{
    public class GetInvoiceByOrderIdQueryHandler
        : IRequestHandler<GetInvoiceByOrderIdQuery, InvoiceDto?>
    {
        private readonly IInvoiceRepository _invoiceRepo;

        public GetInvoiceByOrderIdQueryHandler(IInvoiceRepository invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }

        public async Task<InvoiceDto?> Handle(
            GetInvoiceByOrderIdQuery request,
            CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepo.GetByOrderIdAsync(request.OrderId);

            if (invoice == null)
                return null;

            return new InvoiceDto
            {
                InvoiceId = invoice.InvoiceId,
                InvoiceDate = invoice.InvoiceDate,
                TotalAmount = invoice.TotalAmount
            };
        }
    }
}
