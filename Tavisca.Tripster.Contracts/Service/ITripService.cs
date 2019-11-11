using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Tripster.Core.Validation;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Service
{
    public interface ITripService
    {
        Task<Response<Trip>> Get(Guid id);
        Task<IEnumerable<Trip>> GetAll();
        Task Add(Trip trip);
        Task Delete(Guid id);
        Task<Trip> Update(Guid id, Trip trip);
    }
}
