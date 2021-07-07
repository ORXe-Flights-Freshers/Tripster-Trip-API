using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Web.Security.UserAuthorization
{
    public class UserAuthorizationHandler : AuthorizationHandler<UserIdRequirement>
    {
        private string _requestBody = "";
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserIdRequirement requirement)
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
            string idToken = "";
            if(headers != null && headers.Contains("Bearer"))
            {
                idToken = headers.Replace("Bearer-", string.Empty);
            }
            
            using (var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                _requestBody = reader.ReadToEnd();
            }
            if (request.Method.Equals("POST"))
            {
                var user = JsonConvert.DeserializeObject<User>(_requestBody);
                if (await requirement.ValidToken(idToken, user.UserId))
                {
                    context.Succeed(requirement);
                }
                else
                    context.Fail();
            }
            else
                context.Fail();
            request.Body.Position = 0;
        }
    }
}
