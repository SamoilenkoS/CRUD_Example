using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CRUD_ASP_API.Services;
using CRUD_DAL.Entities;

namespace CRUD_ASP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task AddAsync([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
        }

        [HttpGet("byId")]
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productService.GetAllProductsAsync();
        }

        [HttpDelete("byId")]
        public async Task<bool> RemoveByIdAsync(int id)
        {
            return await _productService.RemoveByIdAsync(id);
        }

        [HttpPost("update")]
        public async Task<bool> UpdateAsync([FromBody] Product product)
        {
            return await _productService.UpdateAsync(product);
        }
    }
}
