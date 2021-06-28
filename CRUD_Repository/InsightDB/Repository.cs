using System.Configuration;
using System.Data;
using CRUD_DAL.InsightDB;
using Insight.Database;

namespace CRUD_Core
{
    public class Repository<T> : IRepository<T> where T : class, IDbConnection, IDbTransaction
    {
        private readonly ConnectionStringSettings _settings;

        /// <summary>
        /// Creates and returns a new DbConnection for the connection string and implments the given interface.
        /// </summary>
        /// <typeparam name="T">The interface to implement on the connection.</typeparam>
        /// <param name="settings">The ConnectionStringSettings containing the connection string.</param>
        /// <returns>A closed connection.</returns>

        public T DbRepository => _settings.As<T>();

        static Repository()
        {
            SqlInsightDbProvider.RegisterProvider();
        }

        public Repository(ConnectionStringSettings connectionStringSettings)
        {
            _settings = connectionStringSettings;
        }
    }
}