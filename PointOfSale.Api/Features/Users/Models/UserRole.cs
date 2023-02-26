using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Features.Users.Models;

[Table("user_roles")]
public class UserRole
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
