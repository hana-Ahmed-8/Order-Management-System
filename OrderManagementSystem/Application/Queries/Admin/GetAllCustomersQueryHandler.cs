using MediatR;
using OrderManagementSystem.Application.DTOs;
using OrderManagementSystem.Core.Interfaces;

namespace OrderManagementSystem.Application.Queries.Admin
{
    public class GetAllCustomersQueryHandler
        : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDto>> Handle(
            GetAllCustomersQuery request,
            CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.ApplicationUser?.Email ?? "",
                UserName = c.ApplicationUser?.UserName ?? ""
            }).ToList();
        }
    }
}
