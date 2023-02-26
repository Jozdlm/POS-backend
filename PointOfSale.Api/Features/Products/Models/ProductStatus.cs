using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Features.Products.Models;

[Table("product_status")]
public class ProductStatus
{
    [Key]
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
}
