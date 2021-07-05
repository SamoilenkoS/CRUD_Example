using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_DAL.DbConfiguration;
using CRUD_DAL.Entities;
using CRUD_DAL.Interfaces;
using LinqToDB;

namespace CRUD_DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CRUDDbConnection _dbConnection;

        public ProductRepository(CRUDDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddProductAsync(Product product)
        {
            await _dbConnection
                .GetTable<Product>()
                .Value(x => x.Title, product.Title)
                .Value(x => x.Price, product.Price)
                .InsertAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbConnection.GetTable<Product>().ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var response = await _dbConnection.GetTable<Product>().Where(x => x.Id == id).ToListAsync();

            return response.FirstOrDefault();
        }

        public async Task<bool> RemoveProductByIdAsync(int id)
        {
            var response = await _dbConnection.GetTable<Product>().DeleteAsync(x => x.Id == id);

            return response == 1;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var result = await _dbConnection.GetTable<Product>()
                .Where(x => x.Id == product.Id)
                .Set(x => x.Title, product.Title)
                .Set(x => x.Price, product.Price).UpdateAsync();

            return result == 1;
        }

        public async Task<IEnumerable<OrderProduct>> GetOrderProductAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
