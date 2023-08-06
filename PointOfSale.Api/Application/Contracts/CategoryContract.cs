namespace PointOfSale.Api.Application.Contracts;

public record CategoryResponse
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
};

public record CategoryDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}
