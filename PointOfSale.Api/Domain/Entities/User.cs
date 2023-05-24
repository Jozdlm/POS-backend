using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Domain.Entities;

[Table("users")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; } = null!;

    [Index(IsUnique = true)]
    [Required]
    public string Email { get; set; } = null!;

    public string Phone { get; set; } = string.Empty;
    public string ImgUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
