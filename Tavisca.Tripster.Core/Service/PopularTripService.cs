using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Interface;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;

namespace Tavisca.Tripster.Core.Service
{
   public class PopularTripService : IPopularTripService
    {
        private PopularTripRepository _popularTripRepository;
        private TripResponse _tripResponse;
        private readonly ILogger<TripService> _logger;
        public PopularTripService(PopularTripRepository popularTripRepository)
        {
            _popularTripRepository = popularTripRepository;
        }
        public async Task<IEnumerable<PopularTrip>> GetPopularTrips()
        {
            //var  popularTrips = new List<PopularTrip>();
            //popularTrips = await _popularTripRepository.GetAll();
            //return popularTrips;
            return await _popularTripRepository.GetAll();
        }

        public async Task AddToPopularTrip(Trip trip)
        {
            await _popularTripRepository.AddToPopularTrip(trip);
        }
    }
}
