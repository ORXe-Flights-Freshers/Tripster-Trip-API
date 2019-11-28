using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Core.Service;
using Tavisca.Tripster.MongoDB.Repository;

namespace Tavisca.Tripster.Web.Security.TripAuthorization
{
    public class UpdateTripRequirement : IAuthorizationRequirement
    {
        
        public UpdateTripRequirement()
        {
        }
        public async Task<bool> ValidateUpdateTrip(string idToken, string userId)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            return payload.Subject == userId;
        }
    }
}
