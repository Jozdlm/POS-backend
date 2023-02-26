using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Features.People.Models;
using PointOfSale.Api.Features.Products.Models;
using PointOfSale.Api.Features.Sales.Models;
using PointOfSale.Api.Features.Users.Models;
using PointOfSale.Api.Models;
using PointOfSale.Api.Shared.Models;

namespace PointOfSale.Api.Core;

public class PointOfSaleContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

    public DbSet<User> User => Set<User>();

    public DbSet<Sale> Sale => Set<Sale>();
    public DbSet<SaleItem> SaleItem => Set<SaleItem>();

    public DbSet<People> Person => Set<People>();
    
    // Views
    public DbSet<ProductKardex> ViewKardex => Set<ProductKardex>();

    public PointOfSaleContext() { }

    public PointOfSaleContext(DbContextOptions<PointOfSaleContext> options) : base(options) { }
}
