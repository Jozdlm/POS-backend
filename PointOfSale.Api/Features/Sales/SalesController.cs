using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Features.Sales.Contracts;
using PointOfSale.Api.Features.Sales.Repositories;
using PointOfSale.Api.Features.Sales.Repositories.Interfaces;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Features.Sales;

[ApiController]
[Route("api/sales")]
public class SalesController : ControllerBase
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public SalesController(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SaleResponse>> GetSales(DateTime? start, DateTime? end)
    {
        if (start != null && end != null)
        {
            var salesByRange = await _saleRepository.FindByDateRange((DateTime)start, (DateTime)end);
            return _mapper.Map<List<SaleResponse>>(salesByRange);
        }
        
        var sales = await _saleRepository.FindAll();
        return _mapper.Map<List<SaleResponse>>(sales);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SaleResponse>> GetSale(int id)
    {
        var sale = await _saleRepository.FindById(id);

        if (sale == null)
        {
            return NotFound();
        }

        return _mapper.Map<SaleResponse>(sale);
    }

    [HttpGet("today")]
    public async Task<ActionResult<decimal>> GetSalesOfToday(DateTime dateTime)
    {
        return await _saleRepository.GetTotalByDay(dateTime);
    }
}