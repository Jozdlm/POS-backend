using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Features.People.Models;

[Table("people")]
public class People
{
    [Key]
    public int Id { get; set; }
    
    [Column("person_type")]
    public int PersonType { get; set; }
    
    public string Name { get; set; } = null!;

    public string Nit { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}
