using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Core;
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
    
    public async Task<IEnumerable<ProductKardex>> GetKardex()
    {
        return await _dbContext.ViewKardex.ToListAsync();
    }
}