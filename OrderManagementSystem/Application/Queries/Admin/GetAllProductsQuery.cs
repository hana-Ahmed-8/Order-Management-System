using MediatR;
using OrderManagementSystem.Core.Entities;

namespace OrderManagementSystem.Application.Queries.Admin
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
    }
}