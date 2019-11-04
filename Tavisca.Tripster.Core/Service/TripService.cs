using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tavisca.Tripster.Contracts.Service;
using Tavisca.Tripster.Core.Validation;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.UnitOfWork;

namespace Tavisca.Tripster.Core.Service
{
    public class TripService : ITripService
    {
        private TripUnitOfWork _tripUnitOfWork;
        private Validator<Trip> _validator;
        public TripService(TripUnitOfWork tripUnitOfWork)
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
