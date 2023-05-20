using PointOfSale.Api.Domain.Entities;

namespace PointOfSale.Api.Features.Products.Repositories;

public interface ICategoryRepository
{
    public Task<IEnumerable<ProductCategory>> FindAll();
    public Task<ProductCategory?> FindById(int id);
    public Task<int> Add(ProductCategory category);
    public Task<int> Update(ProductCategory category);
    public Task<bool> AlreadyExists(int id);
}
