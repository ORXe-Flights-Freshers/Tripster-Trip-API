using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Service;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Web.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll());
        }
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            var transferObject = _userService.Get(email);
            if (transferObject.ModelObject != null) return Ok(transferObject.ModelObject);
            return NotFound(transferObject.ErrorMessage);
        }
        [HttpPut("{email}")]
        public IActionResult Put(string email, [FromBody] User user)
        {
            _userService.Update(email, user);
            return Ok(user);
        }
        //[Route("createTrip")]
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            _userService.Add(user);
            return user;
        }
        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            _userService.Delete(email);
            return Ok("Success");
        }
    }
}
