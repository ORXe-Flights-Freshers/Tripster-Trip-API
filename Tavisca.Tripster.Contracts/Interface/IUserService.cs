using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Contracts.Interface
{
    public interface IUserService
    {
        Task<UserResponse> GetUserById(string id);
        Task<IEnumerable<User>> GetAllUsers();
        Task CreateUser(User trip);
        Task <UserResponse>CreateUser(string id, User user);
    }
}
