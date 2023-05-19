using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PointOfSale.Api.Features.Products.Models;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Features.Sales.Models;

[Table("sale_items")]
public class SaleItem
{
    [Key]
    public int Id { get; set; }
    
    public int SaleId { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
    
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
}