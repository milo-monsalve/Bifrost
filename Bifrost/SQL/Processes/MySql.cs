using System.Reflection;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Bifrost.SQL.Processes
{
        public class MySql
    {
        public static List<T> SpToList<T>(string app, string storedProcedure, MySqlParameter parameter)
        {
            using (MySqlConnection connection = Connections.MySql.Get(app))
            using (MySqlCommand command = new MySqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return Convert.ReaderToList<T>(command.ExecuteReader());
            }
        }

        public static List<T> SpToList<T>(string app, string storedProcedure, MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = Connections.MySql.Get(app))
            using (MySqlCommand command = new MySqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (MySqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return Convert.ReaderToList<T>(command.ExecuteReader());
            }
        }

        public static string SpToStringScalar(string app, string storedProcedure, MySqlParameter parameter)
        {
            using (MySqlConnection connection = Connections.MySql.Get(app))
            using (MySqlCommand command = new MySqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return command.ExecuteScalar().ToString();
            }
        }

        public static string SpToStringScalar(string app, string storedProcedure, MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = Connections.MySql.Get(app))
            using (MySqlCommand command = new MySqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (MySqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return command.ExecuteScalar().ToString();
            }
        }

        public static int SpToIntScalar(string app, string storedProcedure, MySqlParameter parameter)
        {
            using (MySqlConnection connection = Connections.MySql.Get(app))
            using (MySqlCommand command = new MySqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static int SpToIntScalar(string app, string storedProcedure, MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = Connections.MySql.Get(app))
            using (MySqlCommand command = new MySqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (MySqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static double SpToDoubleScalar(string app, string storedProcedure, MySqlParameter parameter)
        {
            using (MySqlConnection connection = Connections.MySql.Get(app))
            using (MySqlCommand command = new MySqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToDouble(command.ExecuteScalar());
            }
        }

        public static double SpToDoubleScalar(string app, string storedProcedure, MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = Connections.MySql.Get(app))
            using (MySqlCommand command = new MySqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (MySqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToDouble(command.ExecuteScalar());
            }
        }

        public static bool SpToBoolScalar(string app, string storedProcedure, MySqlParameter parameter)
        {
            using (MySqlConnection connection = Connections.MySql.Get(app))
            using (MySqlCommand command = new MySqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToBoolean(command.ExecuteScalar());
            }
        }

        public static bool SpToBoolScalar(string app, string storedProcedure, MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = Connections.MySql.Get(app))
            using (MySqlCommand command = new MySqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (MySqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToBoolean(command.ExecuteScalar());
            }
        }

        public static MySqlParameter[] EntityToParameters<T>(T obj)
        {

            PropertyInfo[] props = typeof(T).GetProperties();
            MySqlParameter[] parameters = new MySqlParameter[props.Length];

            int index = 0;
            foreach (PropertyInfo property in props)
            {
                parameters[index] = new MySqlParameter(property.Name, property.GetValue(obj));

                index++;
            }

            return parameters;
        }
    }

}