using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Application.Contracts;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Domain.Interfaces;

namespace PointOfSale.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryRepository categoryRepository, IProductRepository productRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<ActionResult> GetCategories()
    {
        var categories = await _categoryRepository.FindAll();
        var categoriesDto = _mapper.Map<List<CategoryResponse>>(categories);

        return Ok(new {
            Status = 200,
            Data = categories,
            categoriesDto.Count
        });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetCategory(int id)
    {
        var category = await _categoryRepository.FindById(id);

        if (category == null)
        {
            return NotFound();
        }

        var categoryDto = _mapper.Map<CategoryResponse>(category);
        return Ok(categoryDto);
    }

    [HttpGet("{id:int}/products")]
    public async Task<ActionResult> GetProductsByCategory(int id){
        var filteredProducts = await _productRepository.FindByCategory(id);
        var productsDto = _mapper.Map<List<ProductDto>>(filteredProducts);

        if (productsDto.Count == 0) {
            return NotFound();
        }
        
        return Ok(new {
            status = 200,
            Data = productsDto,
            productsDto.Count
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
    {
        var category = _mapper.Map<ProductCategory>(categoryDto);
        var result = await _categoryRepository.Add(category);

        if (result == 0)
        {
            return BadRequest(new
            {
                message = "Ah ocurrido un error al intentar crear la categoría, comuniquese con sistemas"
            });
        }

        return Ok(new
        {
            message = "Categoría creada con exito"
        });
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
            return BadRequest(new
            {
                message = "A ocurrido un error al intentar actualizar, comuniquese con sistemas"
            });
        }

        return Ok(new
        {
            message = "Categoría editada correctamente"
        });
    }
}
