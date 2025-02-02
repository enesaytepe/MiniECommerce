using Domain.Entities;
using Domain.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext, int>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context) { }
}