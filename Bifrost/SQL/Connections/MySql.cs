using MySql.Data.MySqlClient;

namespace Bifrost.SQL.Connections
{
    public class MySql
    {
        public static MySqlConnection Get(string appName)
        {
            MySqlConnection connection = new MySqlConnection() { ConnectionString = ConnectionStrings.Get(appName) };
            connection.Open();
            return connection;
        }
    }
}