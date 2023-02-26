using PointOfSale.Api.Shared.Models;

namespace PointOfSale.Api.Shared.Repositories.Interfaces;

public interface IKardexRepository
{
    public Task<IEnumerable<ProductKardex>> GetKardex();
}