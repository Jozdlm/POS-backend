using PointOfSale.Api.Features.Products.Contracts;
using PointOfSale.Api.Features.Products.Models;

namespace PointOfSale.Api.Features.Products.Repositories;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> FindAll();
    public Task<Product?> FindById(int id);
    public Task<IEnumerable<Product>> FindByName(string productName);
    public Task<IEnumerable<Product>> FindByCategory(string categoryName);
    public Task<bool> AlreadyExists(int id);
    public Task<int> Add(Product product);
    public Task<int> Update(Product product);
    public Task<int> Delete(int id);
}
