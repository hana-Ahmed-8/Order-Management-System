using MediatR;
using OrderManagementSystem.Application.DTOs;
using System.Collections.Generic;

namespace OrderManagementSystem.Application.Queries.Admin
{
    
    public class GetAllCustomersQuery : IRequest<List<CustomerDto>>
    {
    }
}
