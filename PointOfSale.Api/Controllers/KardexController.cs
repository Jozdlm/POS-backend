using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Application.Contracts;
using PointOfSale.Api.Domain.Interfaces;

namespace PointOfSale.Api.Controllers;

[ApiController]
[Route("api/kardex")]
public class KardexController : ControllerBase
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IPurchaseItemRepository _purchaseItemRepository;
    private readonly IMapper _mapper;

    public KardexController(ISaleItemRepository saleItemsRepository, IPurchaseItemRepository purchaseItemRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemsRepository;
        _purchaseItemRepository = purchaseItemRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok(new { message = "Hello" });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetKardexById(int id)
    {
        var saleItems = await _saleItemRepository.FindSaleItemsByProduct(id);
        var purchaseItems = await _purchaseItemRepository.FindPurchaseItemsByProduct(id);

        var kardexItems = saleItems
            .Select(saleItem => _mapper.Map<ProductKardex>(saleItem))
            .Concat(purchaseItems.Select(purchaseItem => _mapper.Map<ProductKardex>(purchaseItem)));

        return Ok(kardexItems);
    }
}
