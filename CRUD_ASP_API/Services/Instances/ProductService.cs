using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_ASP_API.Services.Interfaces;
using CRUD_DAL.Entities;
using CRUD_DAL.InsightDB;

namespace CRUD_ASP_API.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbContext _dbContext;
        public ProductService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProductAsync(Product product)
        {
            await _dbContext.ProductRepository.AddProductAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.ProductRepository.GetAllProductsAsync();
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            return await _dbContext.ProductRepository.RemoveProductByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            return await _dbContext.ProductRepository.UpdateProductAsync(product);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.ProductRepository.GetProductByIdAsync(id);
        }
    }
}
