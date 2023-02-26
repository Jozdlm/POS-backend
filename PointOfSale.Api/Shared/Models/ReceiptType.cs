using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Shared.Models;

[Table("receipt_type")]
public class ReceiptType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}