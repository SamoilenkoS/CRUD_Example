using System;
using CRUD_DAL.DbConfiguration;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD_DAL
{
    public static class Linq2DbExtensions
    {
        public static void AddDatabase<TDatabaseImplementation>(
            this IServiceCollection services,
            Action<DatabaseConnectionOptions> configure)
            where TDatabaseImplementation : DataConnection
        {
            services.AddScoped<TDatabaseImplementation>();
            services.AddScoped<DataConnection, TDatabaseImplementation>(p => p.GetService<TDatabaseImplementation>());
            services.AddSingleton<MappingSchema, CRUDMappingSchema>();
            services.Configure(configure);
        }
        public static void UseSqlServer(this DatabaseConnectionOptions options, string connectionString)
        {
            options.ConnectionString = connectionString;
            options.DataProvider = new SqlServerDataProvider("Default", SqlServerVersion.v2012);
        }
    }
}
