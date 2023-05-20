using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Domain.Entities;

[Table("purchase_items")]
public class PurchaseItem
{
    [Key]
    public int Id { get; set; }

    public int PurchaseId { get; set; }
    public virtual Purchase Purchase { get; set; } = null!;

    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public string Batch { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int CurrentStock { get; set; }
    public decimal PurchasePrice { get; set; }
}
