using ERCMS.Domain.Enums;

namespace ERCMS.Domain.Responses.Errors;

public abstract class StudentError
{
    public static Error NotFound(Guid id) => new(ErrorType.NotFound, $"Student with an '{id}' is not found in the database.");
}