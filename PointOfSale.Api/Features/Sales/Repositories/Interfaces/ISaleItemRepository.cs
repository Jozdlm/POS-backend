using PointOfSale.Api.Domain.Entities;

namespace PointOfSale.Api.Features.Sales.Repositories.Interfaces;

public interface ISaleItemRepository
{
    public Task<IEnumerable<SaleItem>> FindSaleItems(int saleId);
    public Task<IEnumerable<SaleItem>> FindSaleItemsByProduct(int productId);
}