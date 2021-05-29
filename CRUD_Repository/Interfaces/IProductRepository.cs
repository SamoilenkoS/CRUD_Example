using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_DAL.Entities;

namespace CRUD_DAL.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<bool> RemoveByIdAsync(int id);
        Task<bool> UpdateAsync(Product product);
    }
}