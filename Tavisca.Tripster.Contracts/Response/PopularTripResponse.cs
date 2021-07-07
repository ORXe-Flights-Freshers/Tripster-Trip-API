using System.Collections.Generic;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Response
{
    public class PopularTripResponse : ServiceResponse
    {
        public IEnumerable<PopularTrip> PopularTrips { get; set; }
    }
}
