using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Interface
{
       public interface IPopularTripService
    {

        Task<IEnumerable<PopularTrip>> GetPopularTrips();
        Task AddToPopularTrip(Trip trip);

    }
}
