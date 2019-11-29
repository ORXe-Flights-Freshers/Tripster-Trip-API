using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Web.Security.TripAuthorization
{
    public class TripAuthorizationHandler : AuthorizationHandler<UpdateTripRequirement>
    {
        private string _requestBody = string.Empty;
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UpdateTripRequirement requirement)
        {
            var authorizationFilter = (AuthorizationFilterContext)context.Resource;
            var httpContext = authorizationFilter.HttpContext;
            var request = httpContext.Request;
            try
            {
                request.EnableRewind();
            }
            catch (Exception)
            {
            }
            string headers = request.Headers["Authorization"];
            string idToken = string.Empty;
            if (headers != null && headers.Contains("Bearer"))
            {
                idToken = headers.Replace("Bearer-", string.Empty);
            }

            using (var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                _requestBody = reader.ReadToEnd();
            }

            var trip = JsonConvert.DeserializeObject<Trip>(_requestBody);

            if(string.IsNullOrWhiteSpace(trip.UserId))
            {
                context.Succeed(requirement);
            }
            
            else if(string.IsNullOrWhiteSpace(idToken))
            {
                context.Fail();
            }
            else
            {
                if (await requirement.ValidateUpdateTrip(idToken, trip.UserId))
                    context.Succeed(requirement);
                else
                    context.Fail();
            }
            request.Body.Position = 0;
        }
    }
}
