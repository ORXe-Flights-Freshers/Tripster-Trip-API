using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts.Entity;

namespace Tavisca.Tripster.MongoDB
{
    public static class DbContext<TEntity>
    {
        private static MongoClient _mongoClient;
        private static IMongoDatabase _database;
        
        public static IMongoCollection<TEntity> MongoCollection()
        {
            DatabaseSettings.Configure();
            _mongoClient = new MongoClient(DatabaseSettings.ConnectionString);
            _database = _mongoClient.GetDatabase(DatabaseSettings.DatabaseName);
            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

    }
}
