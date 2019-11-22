using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tavisca.Tripster.Contracts.Interface;

namespace Tavisca.Tripster.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularTripController : ControllerBase
    {
        private readonly IPopularTripService _popularTripService;
        private readonly ILogger<TripController> _logger;
        public PopularTripController( IPopularTripService popularTripService, ILogger<TripController> logger)
        {
            _popularTripService = popularTripService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> PopularTrip()
        {
            var popularTrips = await _popularTripService.GetPopularTrips();
            return Ok(popularTrips);
        }
    }
}