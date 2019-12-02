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
                           TripResponse tripResponse, ILogger<TripService> logger = null)
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
                _tripResponse.Message = $"Trip with {id} not found";
                _logger?.LogError($"{typeof(TripService).Name}: {_tripResponse.Message}");
            }
            else
            {
                _tripResponse.Trip = trip;
            }
            return _tripResponse;
        }

        public async Task<IEnumerable<Trip>> GetAllTrips()
        {
            return await _tripRepository.GetAll();
        }

        private async Task<bool> ValidateIncomingTrip(Guid id, Trip trip)
        {
            var storedTrip = await _tripRepository.GetTripById(id);
            if (storedTrip == null)
                return false;
            if (string.IsNullOrWhiteSpace(trip.UserId))
            {
                if (string.IsNullOrWhiteSpace(storedTrip.UserId) == true)
                    return true;
                return false;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(storedTrip.UserId) == true)
                    return true;
                else if (storedTrip.UserId != trip.UserId)
                    return false;
                return true;
            }
        }

        public async Task<TripResponse> UpdateTrip(Guid id, Trip trip)
        {
            if(ValidateIncomingTrip(id, trip).Result == false)
            {
                _tripResponse.Message = $"An unauthorized attempt was made to update trip {id}";
                _logger?.LogCritical($"{typeof(TripService).Name}: {_tripResponse.Message}");
                return _tripResponse;
            }
            var updatedTrip = await _tripRepository.UpdateTrip(id, trip);
            if(updatedTrip == null)
            {
                _tripResponse.Message = $"Trip with {id} not found";
                _logger?.LogError($"{typeof(TripService).Name}: {_tripResponse.Message}");
            }
            else
            {
                _tripResponse.Trip = updatedTrip;
            }
            return _tripResponse;
        }

        public Task<IEnumerable<Trip>> GetTripByUserID(string id)
        {
           return   _tripRepository.GetTripByUserId(id);
        }
    }
}
