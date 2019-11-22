using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Interface
{
    public interface ITripService
    {
        Task<TripResponse> GetTripById(Guid id);
        Task<IEnumerable<Trip>> GetAllTrips();
        Task CreateTrip(Trip trip);
        Task<TripResponse> UpdateTrip(Guid id, Trip trip);
        
    }
}
