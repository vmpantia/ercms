using ERCMS.Domain.Requests;

namespace ERCMS.Application.Features.Students.GetStudentById;

public sealed record GetStudentByIdQuery(Guid Id) : IQuery;