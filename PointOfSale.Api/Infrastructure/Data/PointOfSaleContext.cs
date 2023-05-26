using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Features.People.Models;

namespace PointOfSale.Api.Infrastructure.Data;

public class PointOfSaleContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

    public DbSet<User> User => Set<User>();

    public DbSet<Sale> Sale => Set<Sale>();
    public DbSet<SaleItem> SaleItem => Set<SaleItem>();

    public DbSet<PurchaseItem> PurchaseItem => Set<PurchaseItem>();

    public DbSet<People> Person => Set<People>();

    public PointOfSaleContext() { }

    public PointOfSaleContext(DbContextOptions<PointOfSaleContext> options) : base(options) { }
}
