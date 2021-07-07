using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Exceptions;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.MongoDB.Repository
{
   public class PopularTripRepository : MongoRepository<PopularTrip>
    {
        public async Task AddToPopularTrip(Trip trip)
        {
            IEnumerable<PopularTrip> allPopularTrips = await GetAll();
            bool tripAlreadyExist = false;
            if (trip == null)
                throw new TripNotFoundException($"{typeof(PopularTripRepository).Name}: " +
                                                $"Trip not found");
            if (trip.Source == null || trip.Destination == null)
                throw new StopNotFoundException($"{typeof(PopularTripRepository).Name}: " +
                                                $"Source or Destination of trip {trip.Id} not found");
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
        private PopularTrip TranslateTripToPopularTrip(Trip trip)
        {
            var popularTrip = new PopularTrip
            {
                Source = TranslateStopToPopularTripStop(trip.Source),
                Destination = TranslateStopToPopularTripStop(trip.Destination)
            };
            return popularTrip;
        }
        private PopularTripStop TranslateStopToPopularTripStop(Stop stop)
        {
            var popularTripStop = new PopularTripStop
            {
                StopId = stop.StopId,
                Name = stop.Name,
                Location = stop.Location
            };
            return popularTripStop;
        }
        public async Task<IEnumerable<PopularTrip>> GetPopularTripsByLimit(int limit)
        {
            var popularTripList = (await GetAll()).OrderByDescending(obj => obj.Count).Take(limit);
            return popularTripList;

        }
    }
}
