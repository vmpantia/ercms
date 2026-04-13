using Microsoft.Extensions.Configuration;

namespace ERCMS.Application.Authentication;

public sealed class AuthenticationSetting
{
    private AuthenticationSetting(IConfiguration configuration)
    {
        AccessToken = new AccessTokenSetting(configuration.GetSection($"{nameof(AuthenticationSetting)}:AccessToken"));
        RefreshToken = new RefreshTokenSetting(configuration.GetSection($"{nameof(AuthenticationSetting)}:RefreshToken"));
    }

    public AccessTokenSetting AccessToken { get; init; }
    public RefreshTokenSetting RefreshToken { get; init; }

    public static AuthenticationSetting Initialize(IConfiguration configuration) => new(configuration);
}

public sealed class AccessTokenSetting(IConfigurationSection configuration)
{
    public string Secret { get; init; } = configuration.GetValue<string>(nameof(Secret))!;
    public string Issuer { get; init; } = configuration.GetValue<string>(nameof(Issuer))!;
    public string Audience { get; init; } = configuration.GetValue<string>(nameof(Audience))!;
    public int ExpirationInMinutes { get; init; } = configuration.GetValue<int>(nameof(ExpirationInMinutes));
}

public sealed class RefreshTokenSetting(IConfigurationSection configuration)
{
    public int ExpirationInDays { get; init; } = configuration.GetValue<int>(nameof(ExpirationInDays));
    public int ThresholdInMinutes { get; init; } = configuration.GetValue<int>(nameof(ExpirationInDays));
}