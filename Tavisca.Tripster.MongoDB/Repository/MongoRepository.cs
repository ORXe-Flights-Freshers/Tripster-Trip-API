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
            var result= _collection.Find(requiredId).FirstOrDefault();
            if(result == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return result;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.Find(entity => true).ToList();
        }

        public void Add(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public void  Delete(Guid id)
        {

            
                var requiredId = Builders<TEntity>.Filter.Eq("_id", id);
                 var result=_collection.FindOneAndDelete(requiredId);
            if(result == null)
            {
                throw new NotFoundException();
            }
             //   return true;
          
           
        }
        public void Update(Guid id, TEntity entity)
        {
            // this can wear out
           
                var requiredId = Builders<TEntity>.Filter.Eq("_id", id);
              var  result= _collection.FindOneAndReplace(requiredId, entity);
            if (result == null)
            {
                throw new NotFoundException();
            }
        }
    }
}
