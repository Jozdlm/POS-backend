using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Application.Contracts;
using PointOfSale.Api.Domain.Interfaces;

namespace PointOfSale.Api.Features.Sales;

[ApiController]
[Route("api/sales/{saleId:int}/items")]
public class SaleItemsController : ControllerBase
{
    private readonly ISaleItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public SaleItemsController(ISaleItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SaleItemApi>> GetItems(int saleId)
    {
        var results = await _itemRepository.FindSaleItems(saleId);
        return _mapper.Map<List<SaleItemApi>>(results);
    }
}