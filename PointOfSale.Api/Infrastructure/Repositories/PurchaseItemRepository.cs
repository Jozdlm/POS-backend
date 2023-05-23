using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Domain.Interfaces;
using PointOfSale.Api.Infrastructure.Data;

namespace PointOfSale.Api.Infrastructure.Repositories;

public class PurchaseItemRepository : IPurchaseItemRepository
{
    private PointOfSaleContext _dbContext;

    public PurchaseItemRepository(PointOfSaleContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PurchaseItem>> FindPurchaseItemsByProduct(int productId)
    {
        return await _dbContext.PurchaseItem
            .Include(x => x.Purchase)
            .Where(x => x.ProductId == productId).ToListAsync();
    }
}
