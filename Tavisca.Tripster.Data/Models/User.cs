using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Data.Models
{
    public class User
    {
        [BsonElement("_id")]
        [BsonIgnoreIfDefault]
 
 
        public string Email { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Guid> Trips { get; set; }
        public string Provider { get; set; }
    }
}
