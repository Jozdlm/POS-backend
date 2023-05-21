using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PointOfSale.Api.Features.People.Models;
using PointOfSale.Api.Features.Users.Models;

namespace PointOfSale.Api.Domain.Entities;

[Table("sales")]
public class Sale
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public virtual People Customer { get; set; } = null!;
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public int ReceiptType { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Total { get; set; }
    public int Status { get; set; }
}
