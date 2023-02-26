using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Shared.Models;

[Table("status_operation")]
public class StatusOperation
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}