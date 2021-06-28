using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_ASP_API.Services.Interfaces;
using CRUD_DAL.Entities;
using CRUD_DAL.Interfaces;

namespace CRUD_ASP_API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            return await _productRepository.RemoveProductByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            return await _productRepository.UpdateProductAsync(product);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }
    }
}
