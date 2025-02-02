using Domain.Entities;

namespace Application.Services.UserService;

public interface IUserService
{
    public Task<User?> GetByEmail(string email);
    public Task<User> GetById(long id);
    public Task<User> Update(User user);
}