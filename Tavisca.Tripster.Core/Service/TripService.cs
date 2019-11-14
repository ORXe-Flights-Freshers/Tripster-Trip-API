using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Service;
using Tavisca.Tripster.Core.Validation;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;

namespace Tavisca.Tripster.Core.Service
{
    public class TripService : ITripService
    {
        private TripRepository _tripUnitOfWork;
        private Validator<Trip> _validator;
        public TripService(TripRepository tripUnitOfWork)
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

        public async Task<Response<Trip>> Get(Guid id)
        {
            var trip = await _tripUnitOfWork.Get(id);
            _validator.Entity = trip;
            _validator.ID = id;
            var response = _validator.GetResponse();
            return await Task.Run(() => response);
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await  _tripUnitOfWork.GetAll();
        }

        public async Task<Trip> Update(Guid id, Trip trip)
        {
            var updatedTrip = await _tripUnitOfWork.Update(id, trip);
            return updatedTrip;
        }
    }
}
