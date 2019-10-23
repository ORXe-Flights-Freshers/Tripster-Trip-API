using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Service
{
    public interface ITripService
    {
        Trip Get(Guid id);
        IEnumerable<Trip> GetAll();
        void Add(Trip trip);
        void Delete(Guid id);
        void Update(Guid id, Trip trip);
    }
}
