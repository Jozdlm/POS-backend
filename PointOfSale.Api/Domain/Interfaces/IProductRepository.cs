using PointOfSale.Api.Domain.Entities;

namespace PointOfSale.Api.Domain.Interfaces;

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
