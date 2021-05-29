using LinqToDB.DataProvider;

namespace CRUD_DAL.DbConfiguration
{
    public class DatabaseConnectionOptions
    {
        public string ConnectionString { get; set; }
        public IDataProvider DataProvider { get; set; }
    }
}
