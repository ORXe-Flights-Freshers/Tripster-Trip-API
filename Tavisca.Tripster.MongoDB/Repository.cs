using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Tripster.MongoDB
{
    public class GenericRepository<TEntity>
    {
        public IMongoCollection<TEntity> Collection { get; set; }
        public GenericRepository()
        {
            Collection = DbContext<TEntity>.MongoCollection();
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Task.Run(() =>Collection.FindAsync(entity => true).Result.ToList());
        }
        public async Task Create(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
        }

    }
}
