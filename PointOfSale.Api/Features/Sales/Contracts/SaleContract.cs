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

public record SaleItemApi
{
    public int id { get; init; }
    public int product_id { get; init; }
    public string product_name { get; init; } = null!;
    public int quantity { get; init; }
    public decimal selling_price { get; init; }
    public decimal discount { get; init; }
    public decimal ammount { get; init; }
}

public record SaleHeaderDto 
{
    public DateTime date {get; init;}
    public int customer_id {get; init;}
    public int user_id {get; init;}
    public int receipt_type {get; init;}
    public decimal total {get; init;}
    public int status_id {get; init;}
}

public record SaleItemDto
{
    public int sale_id {get; init;}
    public int product_id {get; init;}
    public int quantity {get; init;}
    public decimal purchase_price {get; init;}
    public decimal selling_price {get; init;}
    public decimal discount {get; init;}
    public decimal tax {get; init;}
}

public record SaleHeaderApi
{
    public int id { get; init; }
    public DateTime date { get; init; }

    public int customer_id {get; init;}
    public string customer_name { get; init; } = null!;

    public int user_id {get; init;}
    public string user_name { get; init; } = null!;
    
    public string receipt_type { get; init; } = string.Empty;
    public decimal total { get; init; }
    public string status { get; init; } = string.Empty;
}