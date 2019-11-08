using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
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
        public async Task Add(Trip trip)
        {
            await _tripUnitOfWork.Add(trip);
        }

        public async Task Delete(Guid id)
        {
            await  _tripUnitOfWork.Delete(id);
        }

        public async Task<TransferObject<Trip>> Get(Guid id)
        {
            var trip = await _tripUnitOfWork.Get(id);
            _validator.Entity = trip;
            _validator.ID = id;
            var transferObject = _validator.GetTransferObject();
            return await Task.Run(() => transferObject);
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await  _tripUnitOfWork.GetAll();
        }

        public async Task Update(Guid id, Trip trip)
        {
            await _tripUnitOfWork.Update(id, trip);
        }
    }
}
