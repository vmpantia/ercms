using System.Security.Cryptography;
namespace ERCMS.Application.Authentication;

public abstract class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100000;
    private const char Separator = '-';

    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;
    
    public static string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

        var hashedPassword = $"{Convert.ToHexString(hash)}{Separator}{Convert.ToHexString(salt)}";
        return hashedPassword;
    }

    public static bool Verify(string hashedPassword, string providedPassword)
    {
        try
        {
            var parts = hashedPassword.Split(Separator);
            var hash = Convert.FromHexString(parts[0]);
            var salt = Convert.FromHexString(parts[1]);

            var inputHash = Rfc2898DeriveBytes.Pbkdf2(providedPassword, salt, Iterations, Algorithm, HashSize);
            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
        catch
        {
            return false;
        }
    }
}