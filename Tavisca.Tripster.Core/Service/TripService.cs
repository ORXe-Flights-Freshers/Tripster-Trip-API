using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Contracts.Service;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.UnitOfWork;

namespace Tavisca.Tripster.Core.Service
{
    public class TripService : ITripService
    {
        private TripUnitOfWork _tripUnitOfWork;
        public TripService(TripUnitOfWork tripUnitOfWork)
        {
            _tripUnitOfWork = tripUnitOfWork;
        }
        public void Add(Trip trip)
        {
            _tripUnitOfWork.Trips.Add(trip);
        }

        public void Delete(Guid id)
        {
            _tripUnitOfWork.Trips.Delete(id);
        }

        public Trip Get(Guid id)
        {
            return _tripUnitOfWork.Trips.Get(id);
        }

        public IEnumerable<Trip> GetAll()
        {
            return _tripUnitOfWork.Trips.GetAll();
        }

        public void Update(Guid id, Trip trip)
        {
            _tripUnitOfWork.Trips.Update(id, trip);
        }
    }
}
