using PointOfSale.Api.Features.Products.Contracts;
using PointOfSale.Api.Features.Products.Models;

namespace PointOfSale.Api.Features.Products.Repositories;

public interface ICategoryRepository
{
    public Task<IEnumerable<ProductCategory>> FindAll();
    public Task<ProductCategory?> FindById(int id);
    public Task<int> Add(ProductCategory category);
    public Task<int> Update(ProductCategory category);
    public Task<bool> AlreadyExists(int id);
}
