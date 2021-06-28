using System.Threading.Tasks;
using CRUD_DAL.Entities;
using CRUD_DAL.InsightDB;
using CRUD_DAL.Interfaces;
using CRUD_Logic.Models;

namespace CRUD_ASP_API.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContext _dbContext;

        public UserService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            return await _dbContext.UserRepository.AddUserAsync(user);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext.UserRepository.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.UserRepository.GetUserByEmailAsync(email);
        }

        public async Task<ValidationResult> ValidateUserAsync(User user)
        {
            var userFromDb = await GetUserByEmailAsync(user.Email);

            if (userFromDb == null || !BCrypt.Net.BCrypt.Verify(user.Password, userFromDb.Password))
            {
                return new ValidationResult {IsSuccessful = false};
            }

            return new ValidationResult
            {
                Id = userFromDb.Id,
                IsSuccessful = true
            };
        }
    }
}
