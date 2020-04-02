using System.Data.SqlClient;

namespace Bifrost.SQL.Connections
{
    public class SqlServer
    {
        public static SqlConnection Get(string appName)
        {
            SqlConnection connection = new SqlConnection() { ConnectionString = ConnectionStrings.Get(appName) };
            connection.Open();
            return connection;
        }
    }
}