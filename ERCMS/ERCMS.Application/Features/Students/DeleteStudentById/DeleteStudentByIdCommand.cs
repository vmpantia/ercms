using ERCMS.Domain.Requests;

namespace ERCMS.Application.Features.Students.DeleteStudentById;

public sealed record DeleteStudentByIdCommand(Guid Id) : ICommand;