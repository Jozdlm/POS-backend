using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Core;
using PointOfSale.Api.Features.Users.Models;

namespace PointOfSale.Api.Features.Users.Repositories;

public class UserRepository : IUserRepository
{
    private PointOfSaleContext _dbContext;

    public UserRepository(PointOfSaleContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> FindAll()
    {
        return await _dbContext.User.ToListAsync();
    }

    public async Task<User?> FindById(int id)
    {
        return await _dbContext.User.FindAsync(id);
    }

    public async Task<bool> AlreadyExists(int id)
    {
        return await _dbContext.User.AnyAsync(x => x.Id == id);
    }

    public async Task<int> UpdateUser(User user)
    {
        _dbContext.Update(user);
        return await _dbContext.SaveChangesAsync();
    }
}
