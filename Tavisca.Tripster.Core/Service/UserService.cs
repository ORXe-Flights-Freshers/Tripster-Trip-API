using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Interface;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;

namespace Tavisca.Tripster.Core.Service
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;
        private UserResponse _userResponse;
        private readonly ILogger<UserService> _logger;
        public UserService(UserRepository userRepository,
                           UserResponse userResponse, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _userResponse = userResponse;
            _logger = logger;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.CreateUser(user.UserId,user);
        }

        public async Task<UserResponse> GetUserById(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if(user == null)
            {
                _userResponse.IsSuccess = false;
                _userResponse.Message = $"User with {id} not found";
                _logger.LogError($"{typeof(UserService).Name}: {_userResponse.Message}");
            }
            else
            {
                _userResponse.IsSuccess = true;
                _userResponse.User = user;
            }
            return _userResponse;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<UserResponse> CreateUser(string id, User user)
        {
            var updatedUser = await _userRepository.CreateUser(id, user);
            if(updatedUser == null)
            {
                _userResponse.IsSuccess = false;
                _userResponse.Message = $"User with {id} not found";
                _logger.LogError($"{typeof(UserService).Name}: {_userResponse.Message}");
            }
            else
            {
                _userResponse.IsSuccess = true;
                _userResponse.User = updatedUser;
            }
            return _userResponse;
        }

    
    }
}
