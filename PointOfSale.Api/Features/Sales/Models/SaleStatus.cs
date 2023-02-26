using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Models;

[Table("sale_status")]
public class SaleStatus
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}