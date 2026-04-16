using ERCMS.Domain.Requests;

namespace ERCMS.Application.Features.Students.UpdateStudent;

public sealed record UpdateStudentCommand(Guid Id, UpdateStudentDto Student) : ICommand;