using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Contracts.DatabaseSettings
{
    public class TripDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
