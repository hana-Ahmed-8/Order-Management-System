using MediatR;
using OrderManagementSystem.Core.Entities;

namespace OrderManagementSystem.Application.Commands.Admin
{
     
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
