using System.Security.Claims;

namespace ERCMS.Domain.Extensions;

public static class AuthExtension
{
    extension(ClaimsPrincipal user)
    {
        public string GetEmail() =>
            user.GetClaimValue(ClaimTypes.Email);
        
        private string GetClaimValue(string claimType) =>
            user.Claims.FirstOrDefault(c => c.Type == claimType)?.Value ?? string.Empty;
    }
}