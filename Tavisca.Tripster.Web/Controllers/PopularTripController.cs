using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tavisca.Tripster.Contracts.Interface;

namespace Tavisca.Tripster.Web.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class PopularTripController : ControllerBase
    {
        private readonly IPopularTripService _popularTripService;
        private readonly ILogger<TripController> _logger;
        public PopularTripController(IPopularTripService popularTripService, ILogger<TripController> logger)
        {
            _popularTripService = popularTripService;
            _logger = logger;
        }

        [HttpGet("{limit}")]
        public async Task<IActionResult> GetPopularTripsByLimit(int limit)
        {
            var popularTrips = await _popularTripService.GetPopularTripsByLimit(limit);
            return Ok(popularTrips);
        }
    }
}