using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts;

namespace Tavisca.Tripster.Dal
{
    public class DatabaseConnection
    {
        private IMongoDatabase _database;
        private TripDatabaseSettings _tripDatabaseSettings;

        public DatabaseConnection(TripDatabaseSettings databaseSettings)
        {

            _tripDatabaseSettings = databaseSettings;

       
        }

        public IMongoDatabase GetDatabase()
        {
            try
            {

                var client = new MongoClient(_tripDatabaseSettings.ConnectionString);
                _database = client.GetDatabase(_tripDatabaseSettings.DatabaseName);
            }
            catch (Exception)
            {

                //  to do logging
            }
           return _database;
           
        }


    }
}
