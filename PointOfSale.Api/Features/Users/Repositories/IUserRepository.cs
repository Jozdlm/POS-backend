using PointOfSale.Api.Features.Users.Models;

namespace PointOfSale.Api.Features.Users.Repositories;

public interface IUserRepository
{
    public Task<IEnumerable<User>> FindAll();
    public Task<User?> FindById(int id);
    public Task<int> UpdateUser(User user);
    public Task<bool> AlreadyExists(int id);
}
