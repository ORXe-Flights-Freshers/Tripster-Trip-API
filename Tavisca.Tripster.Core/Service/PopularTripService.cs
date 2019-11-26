using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Exceptions;
using Tavisca.Tripster.Contracts.Interface;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;

namespace Tavisca.Tripster.Core.Service
{
   public class PopularTripService : IPopularTripService
    {
        private PopularTripRepository _popularTripRepository;
        private PopularTripResponse _popularTripResponse;
        private readonly ILogger<TripService> _logger;
        public PopularTripService(PopularTripRepository popularTripRepository,
                                  PopularTripResponse popularTripResponse, ILogger<TripService> logger)
        {
            _popularTripRepository = popularTripRepository;
            _popularTripResponse = popularTripResponse;
            _logger = logger;
        }
        public async Task<PopularTripResponse> GetPopularTripsByLimit(int limit)
        {
            var popularTrips = await _popularTripRepository.GetPopularTripsByLimit(limit);
            if (popularTrips == null)
            {
                _popularTripResponse.IsSuccess = false;
                _popularTripResponse.Message = "Popular trips do not exist";
            }
            else
            {
                _popularTripResponse.IsSuccess = true;
                _popularTripResponse.PopularTrips = popularTrips;
            }
            return _popularTripResponse;
        }
     
        public async Task AddToPopularTrip(Trip trip)
        {
            try
            {
                await _popularTripRepository.AddToPopularTrip(trip);
                _popularTripResponse.IsSuccess = true;
            }
            catch (TripNotFoundException tnfe)
            {
                _popularTripResponse.IsSuccess = false;
                _logger.LogError(tnfe.Message);
            }
            catch (StopNotFoundException snfe)
            {
                _popularTripResponse.IsSuccess = false;
                _logger.LogError(snfe.Message);
            }
        }
    }
}
