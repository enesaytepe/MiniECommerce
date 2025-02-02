using Domain.Entities;
using Domain.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, BaseDbContext, long>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context) { }
}