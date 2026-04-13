using ERCMS.Domain.Enums;
using ERCMS.Domain.Responses;

namespace ERCMS.Api.Extensions;

public static class ResultsExtension
{
    public static IResult MatchToResults(this Result result)
    {
        if (result == null) throw new Exception("Result cannot be NULL.");

        if (result.IsSuccess) return Results.Ok(result);

        return result.Error?.Type switch
        {
            ErrorType.NotFound => Results.NotFound(result),
            _ => Results.BadRequest(result)
        };
    }
}