using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts.DatabaseSettings;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;

namespace Tavisca.Tripster.MongoDB.UnitOfWork
{
    public class UserUnitOfWork
    {
        private IMongoDatabase _database;
        private MongoRepository<User> _users;

        public UserUnitOfWork(TripDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            _database = client.GetDatabase(databaseSettings.DatabaseName);
        }

        public MongoRepository<User> User
        {
            get
            {
                if (_users == null) _users = new MongoRepository<User>(_database);
                return _users;
            }
        }
    }
}
