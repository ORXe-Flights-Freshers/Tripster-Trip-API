using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.DatabaseSettings;
using Tavisca.Tripster.Contracts.Repository;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;

namespace Tavisca.Tripster.MongoDB.UnitOfWork
{
    public class TripUnitOfWork
    {
        private IMongoDatabase _database;
        private IRepository<Trip> _trips;
        private MongoClient _client;
        private IClientSessionHandle _session;
        public TripUnitOfWork(TripDatabaseSettings databaseSettings)
        {
            _client = new MongoClient(databaseSettings.ConnectionString);
            _database = _client.GetDatabase(databaseSettings.DatabaseName);
            _trips = new MongoRepository<Trip>(_database);
        }
        public async Task Add(Trip trip)
        {
            _session  = await _client.StartSessionAsync();
            _session.StartTransaction();
            await _trips.Add(trip);
            _session.CommitTransaction();
        }

        public async Task<Trip> Get(Guid id)
        {
            var trip = await _trips.Get(id);
            return trip;
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _trips.GetAll();
        }

        public async Task Delete(Guid id)
        {
            _session = await _client.StartSessionAsync();
            _session.StartTransaction();
            await _trips.Delete(id);
            _session.CommitTransaction();
        }

        public async Task<Trip> Update(Guid id, Trip trip)
        {
            _session = await _client.StartSessionAsync();
            _session.StartTransaction();
            var updatedTrip = await _trips.Update(id, trip);
            _session.CommitTransaction();
            return updatedTrip;
        }
        
    }
}
