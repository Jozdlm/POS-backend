using PointOfSale.Api.Domain.Entities;

namespace PointOfSale.Api.Domain.Interfaces;

public interface IPurchaseItemRepository
{
    public Task<IEnumerable<PurchaseItem>> FindPurchaseItemsByProduct(int productId);
}
