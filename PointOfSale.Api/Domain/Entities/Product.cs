using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Domain.Entities;

[Table("products")]
public class Product
{
    [Key]
    public int Id { get; set; }
    public string Barcode { get; set; } = string.Empty;
    
    [Index(IsUnique = true)]
    public string Name { get; set; } = string.Empty;

    public int MinStock { get; set; }
    public decimal SellingPrice { get; set; }
    public string ImgUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public int CategoryId { get; set; }
    public virtual ProductCategory Category { get; set; } = null!;
}
