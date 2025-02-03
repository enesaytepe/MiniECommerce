using Domain.Entities;
using Domain.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CategoryRepository : EfRepositoryBase<Category, BaseDbContext, long>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context)
        : base(context) { }
}