using ERCMS.Domain.Enums;

namespace ERCMS.Domain.Responses.Errors;

public sealed record Error(ErrorType Type, string Message, object? Value = null);