using MediatR;

namespace OrderManagementSystem.Application.Commands.Admin
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}

