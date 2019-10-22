using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.Data.Utility;

namespace Tavisca.Tripster.Contracts.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private List<Trip> _tripList;
        public BaseRepository()
        {
            _tripList = TripCollection.GetTrips();
        }
        public virtual void Add(TEntity entity)
        {
            _tripList.Add(entity as Trip);
        }

        public virtual void Delete(Guid id)
        {
            _tripList.Remove(GetTrip(id));
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
        public virtual List<Trip> GetAllTrips()
        {
            return _tripList;
        }
        public virtual void Update(Guid id, TEntity updatedTrip)
        {
            (updatedTrip as Trip).Id = id;
            _tripList.Remove(Get(id) as Trip);
            _tripList.Add(updatedTrip as Trip);
        }

        public virtual TEntity Get(Guid id)
        {
            return _tripList.Find(t => t.Id == id) as TEntity;
        }
        public virtual Trip GetTrip(Guid id)
        {
            return _tripList.Find(t => t.Id == id);
        }
    }
}
