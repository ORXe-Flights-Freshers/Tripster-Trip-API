using System;
using System.Collections.Generic;



namespace Tavisca.Tripster.Contracts
{
    public interface ITripService
    {
        Response Get(Guid id);
        Response GetAll();
        Response Add(Trip trip);
        Response Delete(Guid id);
        Response Update(Guid id, Trip trip);
    }
}
