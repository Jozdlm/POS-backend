using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Domain.Interfaces;
using PointOfSale.Api.Infrastructure.Data;

namespace PointOfSale.Api.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly PointOfSaleContext _dbContext;

    public ProductRepository(PointOfSaleContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> FindAll()
    {
        return await _dbContext.Products
            .Include(x => x.Category)
            .ToListAsync();
    }

    public async Task<Product?> FindById(int id)
    {
        return await _dbContext.Products
            .Include(x => x.Category)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Product>> FindByName(string productName)
    {
        return await _dbContext.Products
            .Include(x => x.Category)
            .Where(x => x.Name.Contains(productName))
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> FindByCategory(int categoryId)
    {
        return await _dbContext.Products
            .Include(x => x.Category)
            .Where(x => x.Category.Id == categoryId)
            .ToListAsync();
    }

    public async Task<bool> AlreadyExists(int id)
    {
        return await _dbContext.Products.AnyAsync(x => x.Id == id);
    }

    public async Task<int> Add(Product product)
    {
        _dbContext.Add(product);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> Update(Product product)
    {
        _dbContext.Update(product);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        _dbContext.Remove(new Product() {Id = id});
        return await _dbContext.SaveChangesAsync();
    }
}