using PointOfSale.Api.Features.Sales.Models;

namespace PointOfSale.Api.Features.Sales.Repositories.Interfaces;

public interface ISaleItemRepository
{
    public Task<IEnumerable<SaleItem>> FindSaleItems(int saleId);
}