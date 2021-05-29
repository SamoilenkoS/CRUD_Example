using LinqToDB.Data;
using LinqToDB.Mapping;
using Microsoft.Extensions.Options;

namespace CRUD_DAL.DbConfiguration
{
    public class CRUDDbConnection : DataConnection
    {
        public CRUDDbConnection(IOptions<DatabaseConnectionOptions> options, MappingSchema mappingSchema)
            : base(options.Value.DataProvider, options.Value.ConnectionString)
        {
            AddMappingSchema(mappingSchema);
        }
    }
}
