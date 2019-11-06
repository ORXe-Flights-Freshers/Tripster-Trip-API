using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tavisca.Tripster.Contracts;
using Tavisca.Tripster.Dal;

namespace Tavisca.Tripster.Core
{
    public class TripService : ITripService
    {
        private TripUnitOfWork _tripUnitOfWork; //should be interface
        private Validator<Trip> _validator;
        public TripService(TripUnitOfWork tripUnitOfWork) //dependency injection
        {
            _validator = new Validator<Trip>();
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

        public TransferObject<Trip> Get(Guid id)
        {
            var trip = _tripUnitOfWork.Trips.Get(id);
            _validator.Entity = trip;
            _validator.ID = id;
            var transferObject = _validator.GetTransferObject();
            return transferObject;
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
