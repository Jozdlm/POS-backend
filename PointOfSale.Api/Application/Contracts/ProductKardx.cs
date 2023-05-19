namespace PointOfSale.Api.Application.Contracts;

public class ProductKardex {
    public int item_id {get; set;}
    public string type {get; set;} = string.Empty;
    public int quantity {get; set;}
    public decimal value {get; set;}
}
