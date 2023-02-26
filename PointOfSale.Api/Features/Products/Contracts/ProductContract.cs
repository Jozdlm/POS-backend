
namespace PointOfSale.Api.Features.Products.Contracts;

public record ProductResponse
{
    public int id { get; init; }
    public string barcode { get; init; } = null!;
    public string product_name { get; init; } = null!;
    public int min_stock { get; init; }
    public decimal selling_price { get; init; }
    public string img_url { get; init; } = null!;
    public CategoryResponse category { get; init; } = null!;
    public bool active { get; init; }
}

public record ProductDto {
    public int? id { get; init; }
    public string barcode {get; init;} = null!;
    public string product_name {get; init;} = null!;
    public int min_stock {get; init;}
    public decimal selling_price {get; init;}
    public string img_url {get; init;} = null!;
    public int category_id {get; init;}
    public bool active {get; init;}   
};