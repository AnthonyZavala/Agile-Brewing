using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using System.Configuration;

namespace WebApplication
{
    public static class ConnectionStringProvider
    {
        public static string MongoDbConnectionString { get { return ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString; } }
        public static string SqliteConnectionString { get { return @"Data Source=|DataDirectory|nhlite.db;Version=3"; } }
    }
}