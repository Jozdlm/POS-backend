using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Features.Sales.Repositories.Interfaces;
using PointOfSale.Api.Infrastructure.Data;

namespace PointOfSale.Api.Features.Sales.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly PointOfSaleContext _dbContext;
    
    public SaleRepository(PointOfSaleContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Sale>> FindAll()
    {
        return await _dbContext.Sale
            .Include(x => x.User)
            .Include(x => x.Customer).ToListAsync();
    }

    public async Task<Sale?> FindById(int id)
    {
        return await _dbContext.Sale
            .Include(x => x.User)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<decimal> GetTotalByDay(DateTime dateTime)
    {
        return await _dbContext.Sale
            .Where(x => x.DateTime == dateTime)
            .Select(x => x.Total).SumAsync();
    }

    public async Task<IEnumerable<Sale>> FindByDateRange(DateTime start, DateTime end)
    {
        return await _dbContext.Sale
            .Where(x => x.DateTime >= start && x.DateTime <= end)
            .Include(x => x.User)
            .Include(x => x.Customer).ToListAsync();
    }

    public async Task<int> Add(Sale sale)
    {
        _dbContext.Add(sale);
        return await _dbContext.SaveChangesAsync();
    }
}