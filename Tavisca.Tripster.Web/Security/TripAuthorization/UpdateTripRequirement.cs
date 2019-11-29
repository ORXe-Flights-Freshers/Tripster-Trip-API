using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;


namespace Tavisca.Tripster.Web.Security.TripAuthorization
{
    public class UpdateTripRequirement : IAuthorizationRequirement
    {
        
        public async Task<bool> ValidateUpdateTrip(string idToken, string userId)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            return payload.Subject == userId;
        }
    }
}
