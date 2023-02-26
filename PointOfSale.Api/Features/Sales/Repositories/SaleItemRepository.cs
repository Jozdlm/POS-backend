using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Core;
using PointOfSale.Api.Features.Sales.Models;
using PointOfSale.Api.Features.Sales.Repositories.Interfaces;

namespace PointOfSale.Api.Features.Sales.Repositories;

public class SaleItemRepository : ISaleItemRepository
{
    private readonly PointOfSaleContext _dbContext;

    public SaleItemRepository(PointOfSaleContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<SaleItem>> FindSaleItems(int saleId)
    {
        return await _dbContext.SaleItem
            .Include(x => x.Product)
            .Where(x => x.SaleId == saleId).ToListAsync();
    }
}