namespace PointOfSale.Api.Features.Users.Contracts;

public record UserResponse(
    int id,
    string username,
    string email,
    string phone,
    string img_url,
    bool active
);

public record UserDto(
    string username,
    string email,
    string phone,
    string img_url,
    bool active
);