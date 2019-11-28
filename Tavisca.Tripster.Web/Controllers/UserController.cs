using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Interface;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Web.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var userList = await _userService.GetAllUsers();
            return userList;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var userResponse = await _userService.GetUserById(id);
            if (userResponse.IsSuccess == true)
            {
                _logger.LogInformation($"{typeof(UserController).Name}: GetUserById request completed successfully");
                return Ok(userResponse.User);
            }
            _logger.LogError($"{typeof(UserController).Name}: GetUserById was not successfully completed");
            return NotFound(userResponse.Message);
        }


        [Authorize(Policy = "ValidUserId")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userService.CreateUser(user);
            return Ok(user);
        }
    }
}
