using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Application.Contracts;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Domain.Interfaces;
using PointOfSale.Api.Features.Products.Contracts;
using PointOfSale.Api.Features.Products.Repositories;

namespace PointOfSale.Api.Controllers.Products;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IPurchaseItemRepository _purchaseItemRepository;

    public ProductsController(
        IProductRepository repository,
        IMapper mapper,
        ISaleItemRepository saleItemRepository,
        IPurchaseItemRepository purchaseItemRepository
    )
    {
        _repository = repository;
        _mapper = mapper;
        _saleItemRepository = saleItemRepository;
        _purchaseItemRepository = purchaseItemRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductResponse>> GetProducts(string? q = "")
    {
        if (q != null)
        {
            var filteredProducts = await _repository.FindByName(q);
            return _mapper.Map<List<ProductResponse>>(filteredProducts);
        }

        var products = await _repository.FindAll();

        return _mapper.Map<List<ProductResponse>>(products);
    }

    [HttpGet("{category}")]
    public async Task<IEnumerable<ProductDto>> GetProductsByCategory(string category)
    {
        var filteredProducts = await _repository.FindByCategory(category);
        return _mapper.Map<List<ProductDto>>(filteredProducts);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductResponse>> GetProduct(int id)
    {
        var product = await _repository.FindById(id);

        if (product == null)
            return NotFound(new { message = $"El producto con el id {id} no fue encontrado" });

        return _mapper.Map<ProductResponse>(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        var result = await _repository.Add(product);

        if (result == 0)
        {
            return BadRequest(
                new
                {
                    message = "Ha ocurrido un error al intentar crear un producto, comuniquese con sistemas"
                }
            );
        }

        return Ok(new { message = "Producto creado con exito" });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
    {
        var alreadyExists = await _repository.AlreadyExists(id);

        if (!alreadyExists)
        {
            return NotFound();
        }

        var product = _mapper.Map<Product>(productDto);
        product.Id = id;

        var result = await _repository.Update(product);

        if (result == 0)
        {
            return BadRequest(
                new
                {
                    message = "Ha ocurrido un error al intentar actualizar el producto, comuniquese con sistemas"
                }
            );
        }

        return Ok(new { message = "Producto actualizado correctamente" });
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var alreadyExists = await _repository.AlreadyExists(id);

        if (!alreadyExists)
        {
            return NotFound();
        }

        var result = await _repository.Delete(id);

        if (result == 0)
        {
            return BadRequest();
        }

        return Ok(new { message = "Producto eliminado correctamente" });
    }

    [HttpGet("kardex/{id:int}")]
    public async Task<IActionResult> GetProductKardex(int id)
    {
        var saleItems = await _saleItemRepository.FindSaleItemsByProduct(id);
        var purchaseItems = await _purchaseItemRepository.FindPurchaseItemsByProduct(id);

        var kardexItems = saleItems
            .Select(saleItem => _mapper.Map<ProductKardex>(saleItem))
            .Concat(purchaseItems.Select(purchaseItem => _mapper.Map<ProductKardex>(purchaseItem)));

        return Ok(kardexItems);
    }
}
