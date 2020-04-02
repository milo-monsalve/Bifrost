using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Bifrost.SQL.Processes
{
    public class Convert
    {
        public static List<T> ReaderToList<T>(SqlDataReader reader)
        {
            List<T> response = new List<T>();

            while (reader.Read())
            {
                T row = Activator.CreateInstance<T>();
                for (int column = 0; column < reader.FieldCount; column++)
                    foreach (var property in typeof(T).GetProperties())
                        if ((reader.GetName(column) == property.Name) && property.CanWrite)
                            if (reader != null && property.PropertyType.Name == "String")
                                property.SetValue(row, reader[property.Name] != DBNull.Value ? reader[property.Name].ToString().Trim():null);
                            else
                                property.SetValue(row, reader[property.Name] != DBNull.Value ? reader[property.Name] : null);


                response.Add(row);
            }

            return response;
        }
        
        public static List<T> ReaderToList<T>(MySqlDataReader reader)
        {
            List<T> response = new List<T>();
            while (reader.Read())
            {
                T row = Activator.CreateInstance<T>();
                for (int column = 0; column < reader.FieldCount; column++)
                    foreach (var property in typeof(T).GetProperties())
                        if ((reader.GetName(column) == property.Name) && property.CanWrite)
                            if (reader != null && property.PropertyType.Name == "String")
                                property.SetValue(row, reader[property.Name].ToString().Trim());
                            else
                                property.SetValue(row, reader[property.Name]);


                response.Add(row);
            }
            return response;
        }
    }
}