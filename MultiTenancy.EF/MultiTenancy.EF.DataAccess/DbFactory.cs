using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace MultiTenancy.EF.DataAccess
{
    public static class DbFactory
    {
        public static DbConnection GetConnection(string dbName, string entity)
        {
            DbConnection connection = null;
            switch (entity)
            {
                case "Practice":
                    connection = GetPracticeConnection(dbName);
                    break;
                case "Hospital":
                    connection = GetHospitalConnection(dbName);
                    break;
            }

            return connection;

        }

        private static DbConnection GetPracticeConnection(string dbName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PracticeEntities"].ConnectionString;
            return new SqlConnection(connectionString.Replace("initial catalog=DB", "initial catalog=" + dbName));

        }

        private static DbConnection GetHospitalConnection(string dbName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HospitalEntities"].ConnectionString;
            return new SqlConnection(connectionString.Replace("initial catalog=DB", "initial catalog=" + dbName));
        }
    }
}
