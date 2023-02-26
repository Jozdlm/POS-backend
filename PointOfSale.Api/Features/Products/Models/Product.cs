using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Features.Products.Models;

[Table("products")]
public class Product
{
    [Key]
    public int Id { get; set; }
    public string Barcode { get; set; } = string.Empty;
    
    [Index(IsUnique = true)]
    public string Name { get; set; } = string.Empty;

    [Column("min_stock")]
    public int MinStock { get; set; }

    [Column("selling_price")]
    public decimal SellingPrice { get; set; }

    [Column("img_url")]
    public string ImgUrl { get; set; } = string.Empty;
    
    public bool Active { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }
    public virtual ProductCategory Category { get; set; } = null!;
}
