using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Interface
{
    public interface IPopularTripService
    {
        Task<PopularTripResponse> GetPopularTripsByLimit(int limit);
        Task AddToPopularTrip(Trip trip);
    }
}
