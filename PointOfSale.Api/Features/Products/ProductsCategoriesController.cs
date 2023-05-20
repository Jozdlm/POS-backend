using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Features.Products.Contracts;
using PointOfSale.Api.Features.Products.Repositories;

namespace PointOfSale.Api.Features.Products;

[ApiController]
[Route("api/products-categories")]
public class ProductsCategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public ProductsCategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryResponse>> GetCategories()
    {
        var categories = await _categoryRepository.FindAll();
        return _mapper.Map<List<CategoryResponse>>(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryResponse>> GetCategory(int id)
    {
        var category = await _categoryRepository.FindById(id);

        if (category == null)
        {
            return NotFound();
        }

        return _mapper.Map<CategoryResponse>(category);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
    {
        var category = _mapper.Map<ProductCategory>(categoryDto);
        var result = await _categoryRepository.Add(category);

        if (result == 0)
        {
            return BadRequest("Ah ocurrido un error al intentar crear la categoría, comuniquese con sistemas");
        }

        return Ok("Categoría creada con exito");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
    {
        var alreadyExists = await _categoryRepository.AlreadyExists(id);

        if (!alreadyExists)
        {
            return NotFound();
        }

        var category = _mapper.Map<ProductCategory>(categoryDto);
        category.Id = id;

        var result = await _categoryRepository.Update(category);

        if (result == 0)
        {
            return BadRequest("A ocurrido un error al intentar actualizar, comuniquese con sistemas");
        }

        return Ok("Categoría editada correctamente");
    }
}