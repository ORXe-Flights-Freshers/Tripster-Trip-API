using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.MongoDB.Repository
{
   public class PopularTripRepository : MongoRepository<PopularTrip>
    {
        public async Task AddToPopularTrip(Trip trip)
        {
            IEnumerable<PopularTrip> allPopularTrips = await GetAll();
            bool tripAlreadyExist = false;
            Console.WriteLine(allPopularTrips);
            foreach (var popularTrip in allPopularTrips)
            {

                if (popularTrip.Source.StopId == trip.Source.StopId && popularTrip.Destination.StopId == trip.Destination.StopId)
                {
                    popularTrip.Count += 1;
                    var requiredId = Builders<PopularTrip>.Update.Set(obj => obj.Count, popularTrip.Count);
                    var updatedEntity = Collection.UpdateOne(obj => obj.Id == popularTrip.Id, requiredId);
                    tripAlreadyExist = true;
                    break;
                }
            }
            if (!tripAlreadyExist)
            {
                var popularTripEntity = TranslateTripToPopularTrip(trip);
                popularTripEntity.Count = 1;
                await Create(popularTripEntity);
            }

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


        public async Task<IEnumerable<PopularTrip>> GetAllPopularTrips()
        {
            var popularTripList = (await GetAll()).OrderByDescending(obj => obj.Count);
            return popularTripList;

        }

        public async Task<IEnumerable<PopularTrip>> GetPopularTripsByLimit(int limit)
        {
            var popularTripList = (await GetAll()).OrderByDescending(obj => obj.Count).Take(limit);
            return popularTripList;

        }
    }
}
