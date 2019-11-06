using System;
using System.Collections.Generic;



namespace Tavisca.Tripster.Contracts
{
    public interface ITripService
    {
        TransferObject<Trip> Get(Guid id);
        IEnumerable<Trip> GetAll();
        void Add(Trip trip);
        void Delete(Guid id);
        void Update(Guid id, Trip trip);
    }
}
