using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tavisca.Tripster.Web.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        [HttpGet("{placeName}")]
        public async Task<string> GetPlacePhotoUrl(string placeName)
        {
            var place = placeName.Replace(" ", "+");
            var queryString = $"{place}+images";
            var url = $"https://google.com/search?q={queryString}";
            var httpClient = new HttpClient();
            var page = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(page);
            var divTags = htmlDocument.DocumentNode.Descendants("div")
                           .Where(tag => tag.InnerHtml.Contains("a"))
                           .Where(nested => nested.InnerHtml.Contains("img")).ToList();
            var firstImgDivTag = divTags[3];
            var anchorTag = firstImgDivTag.Descendants("a").ToList();
            var imageInnerHtml = anchorTag[0].OuterHtml;
            var imageUrl = imageInnerHtml.Split("imgurl=");
            var imageLink = imageUrl[1].Split("\"")[0];
            return imageLink;
        }
    }
}
