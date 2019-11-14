using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Interface
{
    public interface ITripService
    {
        Task<TripResponse> Get(Guid id);
        Task<IEnumerable<Trip>> GetAll();
        Task Add(Trip trip);
        //Task Delete(Guid id);
        Task<Trip> Update(Guid id, Trip trip);
    }
}
