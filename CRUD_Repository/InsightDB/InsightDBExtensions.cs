using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Insight.Database;

namespace CRUD_DAL.InsightDB
{
    public static class InsightDBExtensions
    {
        public static T As<T>(this ConnectionStringSettings settings) where T : class => settings.Connection().As<T>();

        public static DbConnection Connection(this ConnectionStringSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            DbConnection dbConnection1 = (DbConnection) null;
            try
            {
                DbConnection dbConnection2 = !string.IsNullOrEmpty(settings.ProviderName)
                    ? DbProviderFactories.GetFactory(settings.ProviderName).CreateConnection()
                    : new SqlConnection();
                dbConnection1 = dbConnection2;
                dbConnection2.ConnectionString = settings.ConnectionString;
                dbConnection1 = null;

                return dbConnection2;
            }
            finally
            {
                dbConnection1?.Dispose();
            }
        }
    }
}