using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Shared.Models;

[Table("kardex")]
public class ProductKardex
{
    [Key]
    public int Id { get; set; }
    public string Product { get; set; } = null!;
    public string Category { get; set; } = null!;
    public int Incomes { get; set; }
    public int Outcomes { get; set; }
    
    [Column("current_stock")]
    public int CurrentStock { get; set; }
    [Column("min_stock")]
    public int MinStock { get; set; }
    [Column("total_cost")]
    public int TotalCost { get; set; }
    [Column("total_price")]
    public int TotalPrice { get; set; }
    [Column("total_earned")]
    public int TotalEarned { get; set; }
}