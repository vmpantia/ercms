using ERCMS.Domain.Requests;

namespace ERCMS.Application.Features.Students.CreateStudent;

public sealed record CreateStudentCommand(CreateStudentDto Student) : ICommand;