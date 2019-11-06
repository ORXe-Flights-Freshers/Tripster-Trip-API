using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Tavisca.Tripster.Contracts;

namespace Tavisca.Tripster.Dal
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
        public TEntity Get(Guid id)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", id);
            return _collection.Find(requiredId).FirstOrDefault();

        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.Find(entity => true).ToList();
        }

        public void Add(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public void Delete(Guid id)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", id);
            _collection.FindOneAndDelete(requiredId);
        }
        public void Update(Guid id, TEntity entity)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", id);
            _collection.FindOneAndReplace(requiredId, entity);
        }
    }
}
