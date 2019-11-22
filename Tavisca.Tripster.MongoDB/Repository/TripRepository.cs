using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.MongoDB.Repository
{
    public class TripRepository : MongoRepository<Trip>
    {
        public async Task<Trip> GetTripById(Guid id)
        {
            var requiredId = Builders<Trip>.Filter.Eq("_id", id);
            return await Task.Run(() => Collection.FindAsync(requiredId).Result.FirstOrDefault());
        }

        public async Task<Trip> UpdateTrip(Guid id, Trip trip)
        {
            var requiredId = Builders<Trip>.Filter.Eq("_id", id);
            var updatedEntity = await Collection.FindOneAndReplaceAsync(requiredId, trip);
            return updatedEntity;
        }

    }
}
