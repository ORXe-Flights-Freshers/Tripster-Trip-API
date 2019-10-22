using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Data.Models
{
    public class Stop
    {
        public string StopId { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public List<Place> Places { get; set; }
    }
}
