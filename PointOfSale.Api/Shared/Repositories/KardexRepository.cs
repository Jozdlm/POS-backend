using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Infrastructure.Data;
using PointOfSale.Api.Shared.Models;
using PointOfSale.Api.Shared.Repositories.Interfaces;

namespace PointOfSale.Api.Shared.Repositories;

public class KardexRepository : IKardexRepository
{
    private readonly PointOfSaleContext _dbContext;

    public KardexRepository(PointOfSaleContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<ViewKardex>> GetKardex()
    {
        return await _dbContext.ViewKardex.ToListAsync();
    }
}