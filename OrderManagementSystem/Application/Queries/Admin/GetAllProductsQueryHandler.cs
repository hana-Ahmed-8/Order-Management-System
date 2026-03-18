using MediatR;
using OrderManagementSystem.Core.Entities;
using OrderManagementSystem.Core.Interfaces;

namespace OrderManagementSystem.Application.Queries.Admin
{
    public class GetAllProductsQueryHandler
        : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(
            GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
