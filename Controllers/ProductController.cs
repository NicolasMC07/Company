
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        } 
        
        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, Product product)
        {
            if (productId != product.Id)
            {
                return BadRequest();
            }

            var success = await _productService.UpdateProductAsync(productId, product);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var success = await _productService.DeleteProductAsync(productId);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}