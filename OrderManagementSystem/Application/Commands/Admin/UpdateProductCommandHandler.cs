using MediatR;
using OrderManagementSystem.Core.Interfaces;
using OrderManagementSystem.Application.DTOs.Product.Admin;

namespace OrderManagementSystem.Application.Commands.Admin
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
             
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                return false;
 
            product.Name = request.Dto.Name;
            product.Price = request.Dto.Price;
            product.Stock = request.Dto.Stock;
 
            await _productRepository.UpdateAsync(product);

            return true;
        }
    }
}