using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts.Repository;
using Tavisca.Tripster.Data.Models;

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
        public TEntity Get(Guid id)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", id);
            return _collection.Find(requiredId).FirstOrDefault();

        }
        public TEntity Get(string email)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", email);
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
        public void Delete(string email)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", email);
            _collection.FindOneAndDelete(requiredId);
        }
        public void Update(Guid id, TEntity entity)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", id);
            _collection.FindOneAndReplace(requiredId, entity);
        }
        public void Update(string email, TEntity entity)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", email);

            _collection.FindOneAndReplace(requiredId, entity);
        }
        public void UpdateUser(string email, TEntity entity)
        {
            var requiredId = Builders<TEntity>.Filter.Eq("_id", email);
            _collection.FindOneAndDelete(requiredId);
            _collection.InsertOne(entity);
             
        }
    }
}
