using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bifrost.SQL.Connection
{

    public class AppModel
    {
        public string AppName { get; set; }
        public string RDBMS { get; set; }
        public int Port { get; set; }
        public string DbProductionName { get; set; }
        public string DbDevelopmentName { get; set; }
        public string DbHostName { get; set; }
        public string DbUserName { get; set; }
        public string DbUserPass { get; set; }
    }

    public class ConnectionStrings
    {
        public static bool DevelopmentMode { get; set; } = true;

        public static string FileConnection { get; set; } = @"C:\Windows\Bifrost.json";

        private static string SQlServerStringConnection(AppModel app)
        {
            return "Server=" + app.DbHostName + ";Database=" + (DevelopmentMode ? app.DbDevelopmentName : app.DbProductionName) + ";User Id=" + app.DbUserName + ";Password=" + app.DbUserPass + ";";
        }

        private static string MySQlStringConnection(AppModel app)
        {
            return "SERVER=" + app.DbHostName + ";Port=" + app.Port.ToString() + ";DATABASE=" + (DevelopmentMode ? app.DbDevelopmentName : app.DbProductionName) + ";UID=" + app.DbUserName + ";PASSWORD=" + app.DbUserPass + ";";
        }

        public static string Get(string appName)
        {
            AppModel application = JsonConvert
            .DeserializeObject<List<AppModel>>(System.IO.File.ReadAllText(FileConnection))
            .Find(app => app.AppName == appName);

            switch (application.RDBMS)
            {
                case "MYSQL": return MySQlStringConnection(application);
                case "SQLSERVER": return SQlServerStringConnection(application);
                default: return SQlServerStringConnection(application);
            }
        }
    }
}