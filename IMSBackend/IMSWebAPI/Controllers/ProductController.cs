using IMSWebAPI.Interfaces;
using IMSWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace IMSWebAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                await _productService.PostProduct(product);
                return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            return await _productService.PutProduct(id, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return await _productService.DeleteProduct(id);
        }

        // ProductsController.cs
        [HttpGet]
        [Route("ProductsForDashboard")]
        public IActionResult GetProductsForDashboard(int page = 1, int pageSize = 10)
        {
            return _productService.GetProductsForDashboard(page, pageSize);
        }

    }
}

