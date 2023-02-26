using System.Security.Cryptography;
using System.Text;

namespace PointOfSale.Api.Features.Auth.Services;

public class AuthService : IAuthService
{
    public string HashPassword(string password)
    {
        var sha256 = SHA256.Create();

        byte[] textBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashValue = sha256.ComputeHash(textBytes);

        // Convert the byte array to string format
        return BitConverter.ToString(hashValue).Replace("-", "");
    }
}