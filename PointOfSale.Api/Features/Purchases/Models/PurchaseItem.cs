using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PointOfSale.Api.Features.Products.Models;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Features.Purchases.Models;

[Table("purchase_items")]
public class PurchaseItem
{
    [Key]
    public int IddetalleIngreso { get; set; }
    
    public int Idingreso { get; set; }
    public virtual Purchase Compra { get; set; } = null!;
    
    public int Idarticulo { get; set; }
    public virtual Product Producto { get; set; } = null!;
    
    public int Cantidad { get; set; }
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }

}