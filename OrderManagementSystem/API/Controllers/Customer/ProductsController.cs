
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.DTOs.Product.Customer;
using OrderManagementSystem.Core.Interfaces;

namespace OrderManagementSystem.API.Controllers.Customer
{

    [ApiController]
    [Route("api/customer/[controller]")]  
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

 
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();

           
            var dto = products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();

            return Ok(dto);
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();

            var dto = new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };

            return Ok(dto);
        }
    }
}
