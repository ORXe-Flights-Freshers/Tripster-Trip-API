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
        public async Task<List<PopularTrip>> GetPopularTrips()
        {
            List<PopularTrip> popularTrips = new List<PopularTrip>();
            IEnumerable<Trip> allTrips = await GetAll();
            Dictionary<string, int> tripCounts = new Dictionary<string, int>() { };
            Dictionary<string, PopularTrip > tripEntities = new Dictionary<string, PopularTrip>() { };

            foreach (var i in allTrips)
            {
                var tripEntity = TranslateTripToPopularTrip(i);
                var key = i.Source.StopId + i.Destination.StopId;

                if (tripCounts.ContainsKey(key))
                {
                    tripCounts[key] = tripCounts[key]+1;
                }
                else
                {
                    tripCounts.Add(key,1);
                    tripEntities.Add(key, tripEntity);
                }
            }

            foreach (KeyValuePair<string, int> tripCount in tripCounts.OrderByDescending(key => key.Value))
            {
                popularTrips.Add(tripEntities[tripCount.Key]);
            }

            return popularTrips;
        }

        PopularTrip TranslateTripToPopularTrip(Trip trip)
        {
            PopularTrip popularTrip = new PopularTrip();
            if (trip != null)
            {
                popularTrip.Source = TranslateStopToPopularTripStop(trip.Source);
                popularTrip.Destination = TranslateStopToPopularTripStop(trip.Destination);
            }

            return popularTrip;
        }
        PopularTripStop TranslateStopToPopularTripStop(Stop stop)
        {
            PopularTripStop popularTripStop = new PopularTripStop();
            if (stop != null)
            {
                popularTripStop.StopId = stop.StopId;
                popularTripStop.Name = stop.Name;
                popularTripStop.Location = stop.Location;
            }
            return popularTripStop;
        }
    
    }
}
