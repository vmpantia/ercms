using ERCMS.Domain.Entities;
using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Infrastructure.DataAccess.Contexts;

namespace ERCMS.Infrastructure.DataAccess.Repositories;

public sealed class StudentRepository(ErcmsDbContext context) : BaseRepository<Student>(context), IStudentRepository;