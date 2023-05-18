using PointOfSale.Api.Core;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Domain.Interfaces;

namespace PointOfSale.Api.Infrastructure.Repositories;

public class PurchaseItemRepository : IPurchaseItemRepository
{
    private PointOfSaleContext _dbContext;

    public PurchaseItemRepository(PointOfSaleContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<PurchaseItem>> FindPurchaseItemsByProduct(int productId)
    {
        throw new NotImplementedException();
    }
}
