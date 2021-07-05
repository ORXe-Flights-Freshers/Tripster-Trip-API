using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Interface
{
       public interface IPopularTripService
    {

        Task<IEnumerable<PopularTrip>> GetAllPopularTrips();
        Task<IEnumerable<PopularTrip>> GetPopularTripsByLimit( int limit);
        Task AddToPopularTrip(Trip trip);
    }
}
