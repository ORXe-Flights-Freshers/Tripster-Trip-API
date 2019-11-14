using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Data.Models
{
    public class Email
    {
        [BsonIgnoreIfDefault]
        [BsonElement("_id")]
        public string EmailId { get; set; }
    }
}
