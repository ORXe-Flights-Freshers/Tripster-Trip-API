using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.MongoDB
{
    public static class DbContext<TEntity>
    {
        private static MongoClient _mongoClient = new MongoClient("mongodb://3.14.69.62:27017");
        private static IMongoDatabase _database = _mongoClient.GetDatabase("TripDB");
        
        public static IMongoCollection<TEntity> MongoCollection()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

    }
}
