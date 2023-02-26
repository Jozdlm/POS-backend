namespace PointOfSale.Api.Features.Auth.Models;

public class UserSession
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
}