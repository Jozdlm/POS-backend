namespace PointOfSale.Api.Features.Sales.Contracts;

public record SaleResponse
{
    public int id { get; init; }
    public DateTime date { get; init; }
    public string customer { get; init; } = null!;
    public string user { get; init; } = null!;
    public string receipt_type { get; init; } = string.Empty;
    public decimal total { get; init; }
    public string status { get; init; } = string.Empty;
}

public record SaleItemDto
{
    public int id { get; init; }
    public int product_id { get; init; }
    public string product_name { get; init; } = null!;
    public int quantity { get; init; }
    public decimal selling_price { get; init; }
    public decimal discount { get; init; }
    public decimal ammount { get; init; }
}