namespace PointOfSale.Api.Features.Products.Contracts;

public record CategoryResponse(
    int id,
    string name,
    string description
);

public record CategoryDto
{
    public string name { get; init; } = null!;
    public string description { get; init; } = null!;
}