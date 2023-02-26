namespace PointOfSale.Api.Features.Auth.Contracts;

public record SessionRequest(
    string email,
    string password
);