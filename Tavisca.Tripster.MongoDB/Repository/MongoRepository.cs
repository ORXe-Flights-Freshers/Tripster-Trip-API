using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Repository;

namespace Tavisca.Tripster.MongoDB.Repository
{
    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IMongoDatabase _database;
        private string _collectionName;
        private IMongoCollection<TEntity> _collection;
        
        public MongoRepository(IMongoDatabase database)
        {
            _database = database;
            _collectionName = typeof(TEntity).Name;
            _collection = _database.GetCollection<TEntity>(_collectionName);
        }
        public async Task<TEntity> Get(Guid id)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", id);
            return await Task.Run(() => _collection.FindAsync(requiredId).Result.FirstOrDefault());

        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Task.Run(() => _collection.FindAsync(entity => true).Result.ToList());
        }

        public async Task Add(TEntity entity)
        {
             await Task.Run(() => _collection.InsertOne(entity));
        }

        public async Task Delete(Guid id)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", id);

            await Task.Run(() => _collection.FindOneAndDelete(requiredId));
        }
        public async Task<TEntity> Update(Guid id, TEntity entity)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", id);
            var updatedEntity = await _collection.FindOneAndReplaceAsync(requiredId, entity);
            return updatedEntity;
        }
    }
}
