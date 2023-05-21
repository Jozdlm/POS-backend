namespace PointOfSale.Api.Application.Contracts;

public class ProductKardex {
    public int item_id {get; set;}
    public string operation_type {get; set;} = string.Empty;
    public string document_num {get; set;} = string.Empty;
    public DateTime date_time {get; set;}
    public int quantity {get; set;}
    public decimal value {get; set;}
}
