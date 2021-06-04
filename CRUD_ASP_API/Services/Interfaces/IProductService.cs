using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_DAL.Entities;

namespace CRUD_ASP_API.Services.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<bool> RemoveByIdAsync(int id);
        Task<bool> UpdateAsync(Product product);
        Task<Product> GetByIdAsync(int id);
    }
}