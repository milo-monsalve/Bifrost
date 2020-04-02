using MySql.Data.MySqlClient;

namespace Bifrost.SQL.Connection
{
    public class MySql
    {
        public static MySqlConnection Connection(string appName)
        {
            MySqlConnection connection = new MySqlConnection() { ConnectionString = ConnectionStrings.Get(appName) };
            connection.Open();
            return connection;
        }
    }
}