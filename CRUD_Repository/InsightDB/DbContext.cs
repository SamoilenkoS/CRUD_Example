using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using CRUD_Core;
using CRUD_DAL.Interfaces;
using Insight.Database;

namespace CRUD_DAL.InsightDB
{
    public class DbContext : DisposableObject, IDbContext
    {
        public Guid Id { get; set; }
        public IDbConnection Connection { get; }

        public DbContext(ConnectionStringSettings connectionStringSettings)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient",
                System.Data.SqlClient.SqlClientFactory.Instance);
            var providerFactory = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
            Connection = providerFactory.CreateConnection();
            Connection.ConnectionString = connectionStringSettings.ConnectionString;

            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Connection.Dispose();
            }
        }

        public async Task<IDbTransaction> BeginTransactionAsync()
        {
            return await Connection.OpenWithTransactionAsync();
        }

        public TRepository CreateRepository<TRepository>() where TRepository : class
        {
            return Connection.As<TRepository>();
        }

        public TRepository CreateRepository<TRepository>(IDbTransaction transaction) where TRepository : class
        {
            return transaction.Connection.As<TRepository>();
        }

        public IProductRepository ProductRepository => CreateRepository<IProductRepository>();
        public IUserRepository UserRepository => CreateRepository<IUserRepository>();
    }
}