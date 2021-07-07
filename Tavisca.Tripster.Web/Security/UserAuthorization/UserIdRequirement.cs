using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Tavisca.Tripster.Web.Security.UserAuthorization
{
    public class UserIdRequirement : IAuthorizationRequirement
    {
        public async Task<bool> ValidToken(string idToken, string userId)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            return payload.Subject == userId;
        }
    }
}
