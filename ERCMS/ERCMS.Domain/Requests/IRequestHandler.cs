using ERCMS.Domain.Responses;

namespace ERCMS.Domain.Requests;

public interface IRequestHandler<in TRequest> where TRequest : IRequest
{
    Task<Result> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}