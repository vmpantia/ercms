using System.Security.Claims;
using System.Text;
using ERCMS.Domain.Entities;
using ERCMS.Domain.Interfaces.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace ERCMS.Application.Authentication;

public sealed class TokenProvider(AuthenticationSetting authenticationSetting, ILogger<TokenProvider> logger) : ITokenProvider
{
    public string GenerateAccessToken(User user)
    {
        try
        {
            var expiration = DateTime.UtcNow.AddMinutes(authenticationSetting.AccessToken.ExpirationInMinutes);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSetting.AccessToken.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var accessTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim(ClaimTypes.Upn, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email)
                ]),
                Expires =  expiration,
                SigningCredentials = credentials,
                Issuer = authenticationSetting.AccessToken.Issuer,
                Audience = authenticationSetting.AccessToken.Audience,
            };

            var handler = new JsonWebTokenHandler();
            var accessToken = handler.CreateToken(accessTokenDescriptor);

            return accessToken;
        }
        catch (Exception ex)
        {
            logger.LogError($"Error occurred while creating access token for user. {ex.Message}");
            throw;
        }
    }
}