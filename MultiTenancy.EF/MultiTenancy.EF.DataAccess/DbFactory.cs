using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace MultiTenancy.EF.DataAccess
{
    public static class DbFactory
    {
        public static string GetConnection(string dbName, string entity)
        {
            // DbConnection connection = null;
            string connection = null;
            switch (entity)
            {
                case "Practice":
                    connection = GetConnectionString(dbName,Constants.PracticeMetadata, "PracticeEntities");
                    break;
                case "Hospital":
                    connection = GetConnectionString(dbName,Constants.HospitalMetadata, "HospitalEntities");
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


        private static string GetConnectionString(string dbName,string metadata,string connection)
        {
           // string connectionString = new ConfigurationSettings.AppSettings["ConnectionString"]);
            string connectionString = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
            System.Data.SqlClient.SqlConnectionStringBuilder scsb = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString.Replace("dbname", dbName));

            EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();
            ecb.Metadata = metadata;
            ecb.Provider = "System.Data.SqlClient";
            ecb.ProviderConnectionString = scsb.ConnectionString;
            return ecb.ConnectionString;
          //  dataContext = new SampleEntities(ecb.ConnectionString);
        }
    }

    public class Constants
    {
        public const string CommonMetadata = @"res://*/Common.csdl|res://*/Common.ssdl|res://*/Common.msl";
        public const string PracticeMetadata = @"res://*/Practice.csdl|res://*/Practice.ssdl|res://*/Practice.msl";
        public const string HospitalMetadata = @"res://*/Hospital.csdl|res://*/Hospital.ssdl|res://*/Hospital.msl";

    }
}
