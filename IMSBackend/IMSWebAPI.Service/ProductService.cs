using IMSWebAPI.DataAccessLayer;
using IMSWebAPI.Interfaces;
using IMSWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMSWebAPI.Service
{
    public class ProductService: ControllerBase, IProductService
    {
        private readonly InventoryDbContext _context;

        public ProductService(InventoryDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }
        public async Task<Product> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
            
        }

        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest("Invalid ID");
            }

            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

        public IActionResult GetProductsForDashboard(int page = 1, int pageSize = 10)
        {
            // Assuming you have a list of products in memory (you can replace this with database access).
            var products = _context.Products.ToList(); // Implement this method.

            // Calculate the total number of products and total pages.
            var totalProducts = products.Count;
            var totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

            // Apply pagination.
            var productsPage = products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Return the paginated results and pagination info.
            return Ok(new
            {
                TotalProducts = totalProducts,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Products = productsPage
            });
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
