using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Tripster.Core.Service;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;

namespace Tavisca.Tripster.Web.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class SendController : Controller
    {
        private SendEmailService _sendService;

        public SendController(SendEmailService sendService)
        {
            _sendService = sendService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmailMessage emailMessage)
        {

            if (ModelState.IsValid)
            {
                var response = _sendService.Send(emailMessage);
                if (response.IsSuccess == true)
                {
                    return Ok(response);
                }
                return StatusCode(500);
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
                return BadRequest(errors);
            }
        }
    }
}
