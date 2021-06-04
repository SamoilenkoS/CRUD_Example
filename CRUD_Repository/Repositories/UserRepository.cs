using System;
using System.Linq;
using System.Threading.Tasks;
using CRUD_DAL.DbConfiguration;
using CRUD_DAL.Entities;
using CRUD_DAL.Interfaces;
using LinqToDB;

namespace CRUD_DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CRUDDbConnection _dbConnection;

        public UserRepository(CRUDDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<User> AddUserAsync(User user)
        {
            user.Id = Convert.ToInt32(await _dbConnection.GetTable<User>()
                .Value(x => x.Email, user.Email)
                .Value(x => x.Password, user.Password)
                .InsertWithIdentityAsync());

            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var response = await _dbConnection.GetTable<User>().Where(x => x.Id == id).ToListAsync();

            return response.FirstOrDefault();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var response = await _dbConnection.GetTable<User>().Where(x => x.Email == email).ToListAsync();

            return response.FirstOrDefault();
        }
    }
}
