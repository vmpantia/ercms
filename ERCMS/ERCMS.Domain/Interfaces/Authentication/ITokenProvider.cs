using ERCMS.Domain.Entities;

namespace ERCMS.Domain.Interfaces.Authentication;

public interface ITokenProvider
{
    string GenerateAccessToken(User user);
}