using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Interface;
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
        public async Task<IEnumerable<Trip>> GetAllTrips()
        {
            var tripList = await _tripService.GetAllTrips();
            return tripList;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripById(Guid id)
        {
            var tripResponse = await _tripService.GetTripById(id);
            if (tripResponse.IsSuccess == true)
                return Ok(tripResponse.Trip);
            return NotFound(tripResponse.Message);
        }

        [HttpGet("popular")]
        public async Task<IActionResult> PopularTrip()
        {
            var popularTrips = await _tripService.GetPopularTrips();
            return Ok(popularTrips);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(Guid id, [FromBody] Trip trip)
        {
            var updatedTrip = await _tripService.UpdateTrip(id, trip);
            return Ok(updatedTrip);
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] Trip trip)
        {
            await _tripService.CreateTrip(trip);
            return Ok(trip);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{   
        //    await _tripService.Delete(id);
        //    return Ok("deleted successfully");
        //}
    }
}
