using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Bifrost.SQL.Processes
{
    public class Convert
    {
        public static List<T> ReaderToList<T>(SqlDataReader reader)
        {
            List<T> response = new List<T>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            int columns = reader.FieldCount;
            while (reader.Read())
            {
                T row = Activator.CreateInstance<T>();
                for (int column = 0; column < columns; column++)
                    foreach (PropertyInfo property in properties)
                        if (reader.GetName(column) == property.Name && !reader.IsDBNull(column) && property.CanWrite)
                            property.SetValue(row,
                                property.PropertyType.Name == "String"
                                    ? System.Convert.ToString(reader.GetValue(column)).Trim()
                                    : reader.GetValue(column));
                
                response.Add(row);
            }

            return response;
        }
        
        public static List<T> ReaderToList<T>(MySqlDataReader reader)
        {
            List<T> response = new List<T>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            int columns = reader.FieldCount;
            while (reader.Read())
            {
                T row = Activator.CreateInstance<T>();
                for (int column = 0; column < columns; column++)
                    foreach (PropertyInfo property in properties)
                        if (reader.GetName(column) == property.Name && !reader.IsDBNull(column) && property.CanWrite)
                            property.SetValue(row,
                                property.PropertyType.Name == "String"
                                    ? System.Convert.ToString(reader.GetValue(column)).Trim()
                                    : reader.GetValue(column));

                response.Add(row);
            }

            return response;
        }
    }
}