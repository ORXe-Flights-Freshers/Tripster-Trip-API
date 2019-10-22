using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Data.Models
{
    public class Place
    {
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public string PlaceType { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
    }
}
