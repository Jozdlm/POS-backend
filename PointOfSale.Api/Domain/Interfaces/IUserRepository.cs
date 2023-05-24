using PointOfSale.Api.Domain.Entities;

namespace PointOfSale.Api.Domain.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User>> FindAll();
    public Task<User?> FindById(int id);
    public Task<int> UpdateUser(User user);
    public Task<bool> AlreadyExists(int id);
}
