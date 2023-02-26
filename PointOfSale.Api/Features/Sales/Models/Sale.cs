using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PointOfSale.Api.Features.People.Models;
using PointOfSale.Api.Features.Users.Models;

namespace PointOfSale.Api.Models;

[Table("sales")]
public class Sale
{
    [Key]
    public int Id { get; set; }
    
    [Column("customer_id")]
    public int CustomerId { get; set; }
    public virtual People Customer { get; set; } = null!;
    
    [Column("user_id")]
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    
    [Column("receipt_type")]
    public int TipoComprobante { get; set; }

    [Column("fecha_hora")]
    public DateTime Date { get; set; }

    [Column("ammount")]
    public decimal Total { get; set; }
    
    public int Status { get; set; }
}
