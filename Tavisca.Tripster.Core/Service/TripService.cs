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
    public class TripService : ITripService
    {
        private TripRepository _tripRepository;
        private TripResponse _tripResponse;
        private readonly ILogger<TripService> _logger;
        public TripService(TripRepository tripRepository,
                           TripResponse tripResponse, ILogger<TripService> logger)
        {
            _tripRepository = tripRepository;
            _tripResponse = tripResponse;
            _logger = logger;
        }

        public async Task CreateTrip(Trip trip)
        {
            await _tripRepository.Create(trip);
        }

        public async Task<TripResponse> GetTripById(Guid id)
        {
            var trip = await _tripRepository.GetTripById(id);
            if(trip == null)
            {
                _tripResponse.IsSuccess = false;
                _tripResponse.Message = $"Trip with {id} not found";
                _logger.LogError($"{typeof(TripService).Name}: {_tripResponse.Message}");
            }
            else
            {
                _tripResponse.IsSuccess = true;
                _tripResponse.Trip = trip;
            }
            return _tripResponse;
        }

        public async Task<IEnumerable<Trip>> GetAllTrips()
        {
            return await _tripRepository.GetAll();
        }

        public async Task<TripResponse> UpdateTrip(Guid id, Trip trip)
        {
            var updatedTrip = await _tripRepository.UpdateTrip(id, trip);
            if(updatedTrip == null)
            {
                _tripResponse.IsSuccess = false;
                _tripResponse.Message = $"Trip with {id} not found";
                _logger.LogError($"{typeof(TripService).Name}: {_tripResponse.Message}");
            }
            else
            {
                _tripResponse.IsSuccess = true;
                _tripResponse.Trip = updatedTrip;
            }
            return _tripResponse;
        }

        public async Task <List<PopularTrip>> GetPopularTrips()
        {
            List<PopularTrip> popularTrips =  new List<PopularTrip>();
            popularTrips = await _tripRepository.GetPopularTrips();
            return popularTrips;
        }
    }
}
