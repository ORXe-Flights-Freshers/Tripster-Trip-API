using Shouldly;
using Tavisca.Tripster.Core.Service;
using Xunit;

namespace Tavisca.Tripster.Tests
{
    public class FuelPriceServiceTests
    {
        private FuelPriceService _fuelPriceService = new FuelPriceService();

        [Fact]
        public void GetPetrolPrice_with_valid_city_returns_correct_petrol_price()
        {
            var cityName = "Mumbai";
            var actual = _fuelPriceService.GetPetrolPrice(cityName).Result;
            actual.ShouldNotBe(-1);
        }
    }
}
