namespace PointOfSale.Api.Features.People.Contracts;

public record CustomerResponse
{
    public int id { get; init; }
    public string name { get; init; } = null!;
    public string nit { get; init; } = null!;
};