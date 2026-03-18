using MediatR;
using OrderManagementSystem.Application.DTOs.Product.Admin;

namespace OrderManagementSystem.Application.Commands.Admin
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public UpdateProductDto Dto { get; set; }

        public UpdateProductCommand(int id, UpdateProductDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}
 
