using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_DAL.Entities;

namespace CRUD_DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}