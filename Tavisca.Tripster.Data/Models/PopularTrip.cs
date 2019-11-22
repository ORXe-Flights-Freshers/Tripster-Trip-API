using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Data.Models
{
   public class PopularTrip
    {
            [BsonRepresentation(BsonType.ObjectId)]
            [BsonElement("_id")]
            public string Id { get; set; }
            public PopularTripStop Source { get; set; }
            public PopularTripStop Destination { get; set; }
            public int Count { get; set; }
    }
}