namespace PointOfSale.Api.Features.Auth.Services;

public interface IAuthService
{
    public string HashPassword(string password);
}