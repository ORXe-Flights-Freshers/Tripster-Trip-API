using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Data.Models
{
    public class Trip
    {
        public Guid Id { get; set; }
        public Stop Source { get; set; }
        public Stop Destination { get; set; }
        public List<Stop> Stops { get; set; }
        public int Mileage { get; set; }
    }
}
