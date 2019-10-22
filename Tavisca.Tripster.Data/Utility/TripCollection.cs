using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Data.Utility
{
    public class TripCollection
    {
        private static List<Trip> _trips { get; set; }

        public static List<Trip> GetTrips()
        {
            if (_trips == null) _trips = new List<Trip>();
            return _trips;
        }
        public static List<Trip> Trips {
            get =>  _trips;
        }
    }
}
