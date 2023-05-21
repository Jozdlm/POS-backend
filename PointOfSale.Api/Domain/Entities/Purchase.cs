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
    public int DocumentType { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Ammount { get; set; }
    public int Status { get; set; }
    
    public int SupplierId { get; set; }
    public virtual People Supplier { get; set; } = null!;
    
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}
