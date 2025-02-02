using Domain.Entities;

namespace Domain.Repositories;

public interface IRefreshTokenRepository : IRepository<RefreshToken, Guid>;