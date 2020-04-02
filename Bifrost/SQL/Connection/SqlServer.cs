using System.Data.SqlClient;

namespace Bifrost.SQL.Connection
{
    public class SqlServer
    {
        public static SqlConnection Connection(string appName)
        {
            SqlConnection connection = new SqlConnection() { ConnectionString = ConnectionStrings.Get(appName) };
            connection.Open();
            return connection;
        }
    }
}