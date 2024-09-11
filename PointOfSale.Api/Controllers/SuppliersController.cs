using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Features.People.Models;
using PointOfSale.Api.Infrastructure.Data;

namespace PointOfSale.Api.Controllers;

[ApiController]
[Route("api/suppliers")]
public class SuppliersController : ControllerBase
{
    private readonly PointOfSaleContext _dbContext;

    public SuppliersController(PointOfSaleContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<People>> GetSuppliers()
    {
        return await _dbContext.Person
            .Where(x => x.PersonType == 2)
            .ToListAsync();
    }
}