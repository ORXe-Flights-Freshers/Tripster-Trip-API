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

        public TripService(TripRepository tripRepository, TripResponse tripResponse)
        {
            _tripRepository = tripRepository;
        }

        public async Task CreateTrip(Trip trip)
        {
            await _tripRepository.Create(trip);
        }

        //public async Task Delete(Guid id)
        //{
        //    await _tripRepository.
        //}

        public async Task<TripResponse> GetTripById(Guid id)
        {
            var trip = await _tripRepository.GetTripById(id);
            if(trip == null)
            {
                _tripResponse.IsSuccess = false;
                _tripResponse.Message = $"Trip with {id} not found";
            }
            else
            {
                _tripResponse.IsSuccess = true;
                _tripResponse.Trip = trip;
                _tripResponse.Message = $"Trip found";
            }
            return _tripResponse;
        }

        public async Task<IEnumerable<Trip>> GetAllTrips()
        {
            return await _tripRepository.GetAll();
        }

        public async Task<Trip> UpdateTrip(Guid id, Trip trip)
        {
            var updatedTrip = await _tripRepository.UpdateTrip(id, trip);
            return updatedTrip;
        }

        public async Task <List<PopularTrip>> GetPopularTrips()
        {
            List<PopularTrip> popularTrips =  new List<PopularTrip>();
            popularTrips = await _tripRepository.GetPopularTrips();
            return popularTrips;
        }
    }
}
