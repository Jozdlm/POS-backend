using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Domain.Interfaces;
using PointOfSale.Api.Features.Sales.Repositories;
using PointOfSale.Api.Features.Sales.Repositories.Interfaces;
using PointOfSale.Api.Infrastructure.Data;
using PointOfSale.Api.Infrastructure.Repositories;
using PointOfSale.Api.Shared.Repositories;
using PointOfSale.Api.Shared.Repositories.Interfaces;

namespace PointOfSale.Api;

public class Startup
{
    private IConfiguration Configuration { get; }
    private const string DevSpecificOrigins = "_devSpecificOrigins";

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<PointOfSaleContext>(mysqlBuilder =>
        {
            mysqlBuilder.UseMySql(
                Configuration.GetConnectionString("MySqlConnection"),
                ServerVersion.Parse("8.0.25-mysql")
            );
        });

        //Dependency Injection for Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<ISaleItemRepository, SaleItemRepository>();
        services.AddScoped<IPurchaseItemRepository, PurchaseItemRepository>();
        services.AddScoped<IKardexRepository, KardexRepository>();

        services.AddCors(options =>
        {
            string[] origins =
            {
                "http://localhost:4200",
                "http://localhost:8000",
                "http://localhost:63345",
                "http://localhost:63342"
            };

            options.AddPolicy(
                name: DevSpecificOrigins,
                policy =>
                {
                    policy.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod();
                }
            );
        });

        services.AddAutoMapper(typeof(Startup));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors(DevSpecificOrigins);

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
