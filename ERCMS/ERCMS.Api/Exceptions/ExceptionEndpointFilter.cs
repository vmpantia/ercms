using System.Net;
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
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var result = Result.Failed(new Error(statusCode, ex.Message));
            return Results.BadRequest(result);
        }
    }
}