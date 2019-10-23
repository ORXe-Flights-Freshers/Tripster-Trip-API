using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts.DatabaseSettings;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;

namespace Tavisca.Tripster.MongoDB.UnitOfWork
{
    public class TripUnitOfWork
    {
        private IMongoDatabase _database;
        private MongoRepository<Trip> _trips;
        private string _collectionName;

        public TripUnitOfWork(TripDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            _database = client.GetDatabase(databaseSettings.DatabaseName);
            _collectionName = databaseSettings.CollectionName;
        }

        public MongoRepository<Trip> Trips
        {
            get
            {
                if (_trips == null) _trips = new MongoRepository<Trip>(_database, _collectionName);
                return _trips;
            }
        }
    }
}
