using Domain.Entities;
using Domain.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext, Guid>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext context) : base(context) { }
}