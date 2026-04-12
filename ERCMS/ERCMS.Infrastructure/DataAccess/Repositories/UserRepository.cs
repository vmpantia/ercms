using ERCMS.Domain.Entities;
using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Infrastructure.DataAccess.Contexts;

namespace ERCMS.Infrastructure.DataAccess.Repositories;

public sealed class UserRepository(ErcmsDbContext context) : BaseRepository<User>(context), IUserRepository;