using AutoMapper;
using PointOfSale.Api.Features.Products.Contracts;
using PointOfSale.Api.Features.Products.Models;

namespace PointOfSale.Api.Core;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<CategoryDto, ProductCategory>()
            .ReverseMap();
        
        CreateMap<ProductCategory, CategoryResponse>();

        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.product_name))
            .ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src => src.img_url))
            .ForMember(dest => dest.MinStock, opt => opt.MapFrom(src => src.min_stock))
            .ForMember(dest => dest.SellingPrice, opt => opt.MapFrom(src => src.selling_price))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.category_id))
            .ReverseMap();

        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.product_name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.img_url, opt => opt.MapFrom(src => src.ImgUrl))
            .ForMember(dest => dest.min_stock, opt => opt.MapFrom(src => src.MinStock))
            .ForMember(dest => dest.selling_price, opt => opt.MapFrom(src => src.SellingPrice))
            .ForMember(dest => dest.category, opt => opt.MapFrom(src => src.Category));
    }
}