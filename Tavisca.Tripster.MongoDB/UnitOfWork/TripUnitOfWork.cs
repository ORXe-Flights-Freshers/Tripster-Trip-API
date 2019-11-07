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
        public TripUnitOfWork(DatabaseConnection databaseConnection)
        {
            _database = databaseConnection.GetDatabase();
        }


        public bool ValidateConnection()
        {
                if (_database == null) return false;
                return true;
        }



        public MongoRepository<Trip> Trips
        {  
            get
            {
                if (_trips == null) 
                _trips = new MongoRepository<Trip>(_database);
                return _trips;
            }
        }
    }
}
