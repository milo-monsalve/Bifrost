using System.Reflection;
using System.Data.SqlClient;
using System.Collections.Generic;
using Bifrost.SQL.Connections;
using Bifrost.SQL.Processes;
using Microsoft.Extensions.Configuration;

namespace Bifrost
{
    public class SqlServerProcesses
    {
        private readonly IConfiguration config;
        public SqlServerProcesses(IConfiguration config)
        {
            this.config = config;
        }
        public static List<T> SpToList<T>(string app, string storedProcedure, SqlParameter parameter)
        {
            using (SqlConnection connection = BifrostSqlServer.Get(app))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return Convert.ReaderToList<T>(command.ExecuteReader());
            }
        }

        public List<T> SpToList<T>(string app, string storedProcedure, SqlParameter parameter, string setting = "app")
        {
            using (SqlConnection connection = BifrostSqlServer.Get(config[setting]))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return Convert.ReaderToList<T>(command.ExecuteReader());
            }
        }

        public static List<T> SpToList<T>(string app, string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection connection = BifrostSqlServer.Get(app))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return Convert.ReaderToList<T>(command.ExecuteReader());
            }
        }

        public List<T> SpToList<T>(string storedProcedure, SqlParameter[] parameters, string setting = "app")
        {
            using (SqlConnection connection = BifrostSqlServer.Get(config[setting]))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return Convert.ReaderToList<T>(command.ExecuteReader());
            }
        }

        public static string SpToStringScalar(string app, string storedProcedure, SqlParameter parameter)
        {
            using (SqlConnection connection = BifrostSqlServer.Get(app))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return command.ExecuteScalar().ToString();
            }
        }

        public string SpToStringScalar(string storedProcedure, SqlParameter parameter, string setting = "app")
        {
            using (SqlConnection connection = BifrostSqlServer.Get(config[setting]))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return command.ExecuteScalar().ToString();
            }
        }

        public static string SpToStringScalar(string app, string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection connection = BifrostSqlServer.Get(app))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return command.ExecuteScalar().ToString();
            }
        }

        public string SpToStringScalar(string storedProcedure, SqlParameter[] parameters, string setting = "app")
        {
            using (SqlConnection connection = BifrostSqlServer.Get(config[setting]))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return command.ExecuteScalar().ToString();
            }
        }

        public static int SpToIntScalar(string app, string storedProcedure, SqlParameter parameter)
        {
            using (SqlConnection connection = BifrostSqlServer.Get(app))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public int SpToIntScalar(string storedProcedure, SqlParameter parameter, string setting = "app")
        {
            using (SqlConnection connection = BifrostSqlServer.Get(config[setting]))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static int SpToIntScalar(string app, string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection connection = BifrostSqlServer.Get(app))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public int SpToIntScalar(string storedProcedure, SqlParameter[] parameters, string setting = "app")
        {
            using (SqlConnection connection = BifrostSqlServer.Get(config[setting]))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static double SpToDoubleScalar(string app, string storedProcedure, SqlParameter parameter)
        {
            using (SqlConnection connection = BifrostSqlServer.Get(app))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToDouble(command.ExecuteScalar());
            }
        }

        public double SpToDoubleScalar(string storedProcedure, SqlParameter parameter, string setting = "app")
        {
            using (SqlConnection connection = BifrostSqlServer.Get(config[setting]))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToDouble(command.ExecuteScalar());
            }
        }

        public static double SpToDoubleScalar(string app, string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection connection = BifrostSqlServer.Get(app))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToDouble(command.ExecuteScalar());
            }
        }

        public double SpToDoubleScalar(string storedProcedure, SqlParameter[] parameters, string setting = "app")
        {
            using (SqlConnection connection = BifrostSqlServer.Get(config[setting]))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToDouble(command.ExecuteScalar());
            }
        }

        public static bool SpToBoolScalar(string app, string storedProcedure, SqlParameter parameter)
        {
            using (SqlConnection connection = BifrostSqlServer.Get(app))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToBoolean(command.ExecuteScalar());
            }
        }

        public bool SpToBoolScalar(string storedProcedure, SqlParameter parameter, string setting = "app")
        {
            using (SqlConnection connection = BifrostSqlServer.Get(config[setting]))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToBoolean(command.ExecuteScalar());
            }
        }

        public static bool SpToBoolScalar(string app, string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection connection = BifrostSqlServer.Get(app))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToBoolean(command.ExecuteScalar());
            }
        }

        public bool SpToBoolScalar(string app, string storedProcedure, SqlParameter[] parameters, string setting = "app")
        {
            using (SqlConnection connection = BifrostSqlServer.Get(config[setting]))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter).Value = parameter.Value;
                return System.Convert.ToBoolean(command.ExecuteScalar());
            }
        }

        public static SqlParameter[] EntityToParameters<T>(T obj)
        {

            PropertyInfo[] props = typeof(T).GetProperties();
            SqlParameter[] parameters = new SqlParameter[props.Length];

            int index = 0;
            foreach (PropertyInfo property in props)
            {
                parameters[index] = new SqlParameter(property.Name, property.GetValue(obj));

                index++;
            }

            return parameters;
        }

    }

}