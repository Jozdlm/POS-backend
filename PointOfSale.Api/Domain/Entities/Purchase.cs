using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PointOfSale.Api.Features.People.Models;
using PointOfSale.Api.Features.Users.Models;

namespace PointOfSale.Api.Domain.Entities;

[Table("purchases")]
public class Purchase
{
    [Key]
    public int Id { get; set; }

    public string DocumentNumber { get; set; } = string.Empty;
    
    public int SupplierId { get; set; }
    public virtual People Supplier { get; set; } = null!;
    
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    
    public string TipoComprobante { get; set; } = null!;
    public string NumCompra { get; set; } = null!;
    public DateTime FechaHora { get; set; }
    public decimal Tax { get; set; }
    public decimal TotalCompra { get; set; }
    public string Estado { get; set; } = null!;
}
