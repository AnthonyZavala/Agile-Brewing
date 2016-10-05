using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using MongoDB.Driver;

namespace MongoDBRepositories
{
    public class Config
    {
        private static IMongoDatabase _database;

        public static void SetConfiguration(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("agilebrewing");
        }

        public static IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
