using ERCMS.Application.Extensions;
using ERCMS.Domain.Responses;
using ERCMS.Domain.Responses.Errors;
using FluentValidation;

namespace ERCMS.Api.Exceptions;

public sealed class ExceptionEndpointFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        try
        {
            return await next(context);
        }
        catch (ValidationException ex)
        {
            var result = Result.Failed(DefaultError.Validation(ex.Errors.ToDictionary()));
            return Results.BadRequest(result);
        }
        catch (Exception ex)
        {
            var result = Result.Failed(DefaultError.Unexpected(ex));
            return Results.BadRequest(result);
        }
    }
}