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
        public FuelPriceService(ILogger<FuelPriceService> logger = null)
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
            var tag = htmlDocument.DocumentNode.Descendants("div")
                                  .Where(n => n.InnerHtml.Contains("class")).ToList()[19];
             
            var indexOfRupeeSymbol = tag.InnerHtml.IndexOf("&#8377");
            tag.InnerHtml = (indexOfRupeeSymbol >= 0) ? tag.InnerHtml.Substring(indexOfRupeeSymbol + 6) : tag.InnerHtml;
            var div = tag.InnerText;
            
            var digits = Regex.Split(div, @"\D+");
            string price = ""; ;
            double petrolPrice = 0.0;
            try
            {
                price = digits[1] + "." + digits[2];
                double.TryParse(price, out petrolPrice);
            }
            catch (Exception)
            {
                _logger?.LogError($"Petrol Price for {cityName} not found");
                return -1;
            }
            return Math.Round(petrolPrice, 2);
        }
    }
}
