using AutoMapper;
using PointOfSale.Api.Features.Products.Contracts;
using PointOfSale.Api.Features.Products.Models;

namespace PointOfSale.Api.Features.Products.Domain;

public class ProductMapperCfg : Profile
{
    public ProductMapperCfg()
    {
        CreateMap<CategoryDto, ProductCategory>().ReverseMap();
    }
}
