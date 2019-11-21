using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    //    var requiredId = Builders<PopularTrip>.Filter.Eq("_id", popularTrip.Id);
                    var requiredId = $"ObjectId(\"{popularTrip.Id}\")";
                    Console.WriteLine(requiredId);
                    var updatedEntity = await Collection.FindOneAndReplaceAsync(requiredId,popularTrip);
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

   

    }
}
