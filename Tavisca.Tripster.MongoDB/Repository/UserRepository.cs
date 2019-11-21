using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.MongoDB.Repository
{
    public class UserRepository : MongoRepository<User>
    {
        public async Task<User> GetUserById(string id)
        {
            var requiredId = Builders<User>.Filter.Eq("_id", id);
            return await Task.Run(() => Collection.FindAsync(requiredId).Result.FirstOrDefault());
        }

        public async Task<User> CreateUser(string id, User user)
        {
            var requiredId = Builders<User>.Filter.Eq("_id", id);
            if (Collection.CountDocuments(filter: requiredId) == 0)
                await Collection.InsertOneAsync(user);

            return user;
        }
        
    }
}
