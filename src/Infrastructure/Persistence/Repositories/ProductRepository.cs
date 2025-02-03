using Domain.Entities;
using Domain.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductRepository : EfRepositoryBase<Product, BaseDbContext, long>, IProductRepository
{
    public ProductRepository(BaseDbContext context)
        : base(context) { }
}