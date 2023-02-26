using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Api.Features.Users.Models;

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
    
    [Column("img_url")]
    public string ImgUrl { get; set; } = string.Empty;
    public bool Active { get; set; }
}
