using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Data.Models
{
    public class PopularTripStop
    {
        public string StopId { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}
