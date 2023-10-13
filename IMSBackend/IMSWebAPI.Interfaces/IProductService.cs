using IMSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IMSWebAPI.Interfaces
{
    public interface IProductService
    {
        public Task<IActionResult> GetProducts();
        public Task<Product> GetProduct(int id);
        public Task<Product> PostProduct(Product product);
        public Task<IActionResult> PutProduct(int id, Product product);
        public Task<IActionResult> DeleteProduct(int id);
        public IActionResult GetProductsForDashboard(int page = 1, int pageSize = 10);
    }
}
