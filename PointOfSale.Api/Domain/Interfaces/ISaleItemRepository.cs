using PointOfSale.Api.Domain.Entities;

namespace PointOfSale.Api.Domain.Interfaces;

public interface ISaleItemRepository
{
    public Task<IEnumerable<SaleItem>> FindSaleItems(int saleId);
    public Task<IEnumerable<SaleItem>> FindSaleItemsByProduct(int productId);
}