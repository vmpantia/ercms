using ERCMS.Domain.Responses;
using ERCMS.Domain.Responses.Errors;

namespace ERCMS.Api.Exceptions;

public sealed class ExceptionEndpointFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        try
        {
            return await next(context);
        }
        catch (Exception ex)
        {
            var result = Result.Failed(DefaultError.Unexpected(ex));
            return Results.BadRequest(result);
        }
    }
}