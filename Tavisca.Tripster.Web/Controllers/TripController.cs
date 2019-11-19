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
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
            
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tripService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var transferObject = _tripService.Get(id);
            if (transferObject.ModelObject != null) return Ok(transferObject.ModelObject);
            return NotFound(transferObject.ErrorMessage);
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Trip trip)
        {
            _tripService.Update(id, trip);
            return Ok(trip);
        }
        //[Route("createTrip")]
        [HttpPost]
        public ActionResult<Trip> Post([FromBody] Trip trip)
        {
            _tripService.Add(trip);
            return trip;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _tripService.Delete(id);
            return Ok("Success");
        }
    }
}
