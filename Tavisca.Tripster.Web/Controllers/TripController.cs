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
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IPopularTripService _popularTripService;
        private readonly ILogger<TripController> _logger;
        public TripController(ITripService tripService, IPopularTripService popularTripService, ILogger<TripController> logger)
        {
            _tripService = tripService;
            _popularTripService = popularTripService;
            _logger = logger;
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
            {
                _logger.LogInformation($"{typeof(TripController).Name}: GetTripById request completed successfully");
                return Ok(tripResponse.Trip);
            }
            _logger.LogError($"{typeof(TripController).Name}: GetTripById was not successfully completed");
            return NotFound(tripResponse.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(Guid id, [FromBody] Trip trip)
        {
            var tripResponse = await _tripService.UpdateTrip(id, trip);
            if (tripResponse.IsSuccess == true)
            {
                _logger.LogInformation($"{typeof(TripController).Name}: UpdateTrip request completed successfully");
                return Ok(tripResponse.Trip);
            }
            _logger.LogError($"{typeof(TripController).Name}: UpdateTrip was not successfully completed");
            return NotFound(tripResponse.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] Trip trip)
        {
            await _tripService.CreateTrip(trip);
            await _popularTripService.AddToPopularTrip(trip);
            return Ok(trip);
        }

        [HttpGet("userid/{id}")]
        public async Task<IEnumerable<Trip>> GetTripByUserId(string id)
        {
            var tripList = await _tripService.GetTripByUserID(id);
            return tripList;
        }
    }
}
