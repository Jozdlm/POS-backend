using PointOfSale.Api.Models;

namespace PointOfSale.Api.Features.Sales.Repositories.Interfaces;

public interface ISaleRepository
{
    public Task<IEnumerable<Sale>> FindAll();
    public Task<Sale?> FindById(int id);
    public Task<decimal> GetTotalByDay(DateTime dateTime);
    public Task<IEnumerable<Sale>> FindByDateRange(DateTime start, DateTime end);
    public Task<int> Add(Sale sale);
}