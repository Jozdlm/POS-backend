using PointOfSale.Api.Core;
using PointOfSale.Api.Features.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace PointOfSale.Api.Features.Products.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly PointOfSaleContext _dbContext;

    public CategoryRepository(PointOfSaleContext dbContext) 
    { 
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ProductCategory>> FindAll()
    {
        return await _dbContext.ProductCategories.ToListAsync();
    }

    public async Task<ProductCategory?> FindById(int id)
    {
        return await _dbContext.ProductCategories.FindAsync(id);
    }

    public async Task<int> Add(ProductCategory category)
    {
        _dbContext.Add(category);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> Update(ProductCategory category)
    {
        _dbContext.Update(category);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> AlreadyExists(int id)
    {
        return await _dbContext.ProductCategories.AnyAsync(x => x.Id == id);
    }
}
