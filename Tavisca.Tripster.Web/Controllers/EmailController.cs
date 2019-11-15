using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;

namespace Tavisca.Tripster.Web.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private EmailRepository _emailRepository;
        public EmailController(EmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Email>> GetAllTrips()
        {
            var emailList = await _emailRepository.GetAll();
            return emailList;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmailById(string id)
        {
            var email = await _emailRepository.GetEmailById(id);
            return Ok(email);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(string id, [FromBody] Email email)
        {
            var updatedEmail = await _emailRepository.UpdateEmail(id, email);
            return Ok(updatedEmail);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] Email email)
        {
            await _emailRepository.Create(email);
            return Ok(email);
        }
    }
}
