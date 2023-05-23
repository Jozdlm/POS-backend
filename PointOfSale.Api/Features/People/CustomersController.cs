using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Infrastructure.Data;

namespace PointOfSale.Api.Features.People;

[ApiController]
[Route("api/cutomers")]
public class CustomersController : ControllerBase
{
    private readonly PointOfSaleContext _dbContext;

    public CustomersController(PointOfSaleContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Models.People>> GetCustomers()
    {
        return await _dbContext.Person
            .Where(x => x.PersonType == 1)
            .ToListAsync();
    }
}