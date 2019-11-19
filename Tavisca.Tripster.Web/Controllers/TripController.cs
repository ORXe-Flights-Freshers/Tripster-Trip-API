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
        public async Task<IEnumerable<Trip>> Get()
        {
            var tripList = await Task.Run(() => _tripService.GetAll());
            return tripList;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var responseObject = await Task.Run(() => _tripService.Get(id));
            if (responseObject.Model != null)
                return Ok(responseObject.Model);
            return NotFound(responseObject.ErrorMessage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Trip trip)
        {
            await Task.Run(() => _tripService.Update(id, trip));
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Trip trip)
        {
            await Task.Run(() =>_tripService.Add(trip));
            return Ok(trip);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {   
            await Task.Run(() => _tripService.Delete(id));
            return Ok("deleted successfully");
        }
    }
}
