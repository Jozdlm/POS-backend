using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Features.Auth.Contracts;
using PointOfSale.Api.Features.Auth.Services;

namespace PointOfSale.Api.Features.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<SessionRequest>> Login(SessionRequest credentials)
    {
        
        
        return credentials;
    }
}