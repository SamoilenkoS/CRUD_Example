using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_DAL.Entities;

namespace CRUD_DAL.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<bool> RemoveProductByIdAsync(int id);
        Task<bool> UpdateProductAsync(Product product);
        Task<IEnumerable<OrderProduct>> GetOrderProductAsync();
    }
}