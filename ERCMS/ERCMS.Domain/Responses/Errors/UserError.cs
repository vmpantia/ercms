using ERCMS.Domain.Enums;

namespace ERCMS.Domain.Responses.Errors;

public abstract class UserError
{
    public static Error UsernameOrEmailAddressNotFound() => new(ErrorType.NotFound, "Username or email address is not found in the database.");
    public static Error PasswordIncorrect() => new(ErrorType.Invalid, "User password is incorrect.");
}