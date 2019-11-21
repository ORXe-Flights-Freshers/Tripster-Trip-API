using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tavisca.Tripster.Core.Service
{
    public class FuelPriceService
    {
        private ILogger<FuelPriceService> _logger;
        public FuelPriceService(ILogger<FuelPriceService> logger)
        {
            _logger = logger;
        }
        public async Task<double> GetPetrolPrice(string cityName)
        {
            var queryString = $"fuel+price+in+{cityName}";
            var url = $"https://google.com/search?q={queryString}";
            var httpclient = new HttpClient();
            var page = await httpclient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(page);
            var div = htmlDocument.DocumentNode.Descendants("div")
                                  .Where(n => n.InnerHtml.Contains("class")).ToList()[19].InnerText;
            var digits = Regex.Split(div, @"\D+");
            string price = "";
            try
            {
                 price = digits[1] + "." + digits[2];
            }
            catch (Exception)
            {
                _logger.LogError($"Petrol Price for {cityName} not found");
            }
            if (double.TryParse(price, out double petrolPrice))
                return Math.Round(petrolPrice, 2);
            return -1;
        }
    }
}
