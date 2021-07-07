using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tavisca.Tripster.Core.Service;

namespace Tavisca.Tripster.Web.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class FuelPriceController : Controller
    {
        private FuelPriceService _fuelPriceService;
        public FuelPriceController(FuelPriceService fuelPriceService)
        {
            _fuelPriceService = fuelPriceService;
        }
        [HttpGet("{cityName}")]
        public async Task<double> GetPetrolPrice(string cityName)
        {
            return await _fuelPriceService.GetPetrolPrice(cityName);
        }
    }
}
