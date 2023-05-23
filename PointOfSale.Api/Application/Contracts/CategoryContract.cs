namespace PointOfSale.Api.Application.Contracts;

public record CategoryResponse
{
    public int id { get; init; }
    public string name { get; init; } = null!;
    public string description { get; init; } = null!;
};

public record CategoryDto
{
    public string name { get; init; } = null!;
    public string description { get; init; } = null!;
}
