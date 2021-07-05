using System.Threading.Tasks;
using CRUD_DAL.Entities;
using CRUD_DAL.Interfaces;
using CRUD_Logic.Models;

namespace CRUD_ASP_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUserAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            return await _userRepository.AddUserAsync(user);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
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
