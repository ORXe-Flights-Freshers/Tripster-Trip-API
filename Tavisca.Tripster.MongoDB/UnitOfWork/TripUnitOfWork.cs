using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Tavisca.Tripster.Contracts;

namespace Tavisca.Tripster.Dal
{
    public class TripUnitOfWork
    {
        private IMongoDatabase _database;
        private MongoRepository<Trip> _trips;

        public TripUnitOfWork(TripDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            _database = client.GetDatabase(databaseSettings.DatabaseName);
        }

        public MongoRepository<Trip> Trips
        {
            get
            {
                if (_trips == null) _trips = new MongoRepository<Trip>(_database);
                return _trips;
            }
        }
    }
}
