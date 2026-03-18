using MediatR;
using OrderManagementSystem.Core.Interfaces;

namespace OrderManagementSystem.Application.Commands.Admin
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
             
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                return false;

           
            await _productRepository.DeleteAsync(product);

            return true;
        }
    }
}