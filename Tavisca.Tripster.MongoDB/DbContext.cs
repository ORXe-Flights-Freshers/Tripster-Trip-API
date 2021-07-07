using MongoDB.Driver;
using Tavisca.Tripster.Contracts.Entity;

namespace Tavisca.Tripster.MongoDB
{
    public static class DbContext<TEntity>
    {
        private static MongoClient _mongoClient;
        private static IMongoDatabase _database;
        
        public static IMongoCollection<TEntity> MongoCollection()
        {
            _mongoClient = new MongoClient(DatabaseSettings.ConnectionString);
            _database = _mongoClient.GetDatabase(DatabaseSettings.DatabaseName);
            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

    }
}
