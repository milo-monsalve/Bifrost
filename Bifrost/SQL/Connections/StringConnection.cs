using System.Collections.Generic;
using Newtonsoft.Json;
using Bifrost.Security.Save;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace Bifrost
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

    public class StringConnection
    {
        private static bool DevelopmentMode { get; set; }

        public static string FileConnection { get; set; } = @"C:\Windows\Bifrost.json";

        private readonly IConfiguration config;

        public StringConnection(IConfiguration config)
        {
            this.config = config;

            DevelopmentMode = Convert.ToBoolean(config["dev"]);
        }

        private static string SQlServerStringConnection(AppModel app)
        {
            return "Server=" + app.DbHostName + ";Database=" + (DevelopmentMode ? app.DbDevelopmentName : app.DbProductionName) + ";User Id=" + app.DbUserName + ";Password=" + Encript.Decode(app.DbUserPass) + ";";
        }

        private static string MySQlStringConnection(AppModel app)
        {
            return "SERVER=" + app.DbHostName + ";Port=" + app.Port.ToString() + ";DATABASE=" + (DevelopmentMode ? app.DbDevelopmentName : app.DbProductionName) + ";UID=" + app.DbUserName + ";PASSWORD=" + Encript.Decode(app.DbUserPass) + ";";
        }

        public static string Get(string appName, bool dev = true)
        {
            DevelopmentMode = dev;

            AppModel application = JsonConvert
            .DeserializeObject<List<AppModel>>(System.IO.File.ReadAllText(FileConnection))
            .Find(app => app.AppName == appName);

            return application.RDBMS switch
            {
                "MYSQL" => MySQlStringConnection(application),
                "SQLSERVER" => SQlServerStringConnection(application),
                _ => SQlServerStringConnection(application),
            };
        }

        public string Get(string settting = "app")
        {
            AppModel application = JsonConvert
            .DeserializeObject<List<AppModel>>(System.IO.File.ReadAllText(FileConnection))
            .Find(app => app.AppName == config[settting]);

            return application.RDBMS switch
            {
                "MYSQL" => MySQlStringConnection(application),
                "SQLSERVER" => SQlServerStringConnection(application),
                _ => SQlServerStringConnection(application),
            };
        }
    }
}