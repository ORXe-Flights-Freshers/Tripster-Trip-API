using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Tripster.Core.Validation;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Service
{
    public interface IUserService
    {
        TransferObject<User> Get(string email);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Delete(string email);
        void Update(string email, User user);
    }
}
