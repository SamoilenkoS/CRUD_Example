using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_DAL.Entities;
using CRUD_Logic.Models;

namespace CRUD_ASP_API.Services
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<ValidationResult> ValidateUserAsync(User user);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
