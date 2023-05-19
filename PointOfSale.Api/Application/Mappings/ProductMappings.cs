using AutoMapper;
using PointOfSale.Api.Application.Contracts;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Features.Products.Contracts;

namespace PointOfSale.Api.Application.Mappings;

public class ProductMappings : Profile
{
    public ProductMappings()
    {
        ProductKardexMap();
        ProductCategoriesMap();
    }

    public void ProductKardexMap()
    {
        CreateMap<PurchaseItem, ProductKardex>()
            .ForMember(dest => dest.item_id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.type, opt => opt.MapFrom(src => "Compra"))
            .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(
                dest => dest.value,
                opt => opt.MapFrom(src => src.Quantity * src.PurchasePrice)
            );

        CreateMap<SaleItem, ProductKardex>()
            .ForMember(dest => dest.item_id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.type, opt => opt.MapFrom(src => "Venta"))
            .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(
                dest => dest.value,
                opt => opt.MapFrom(src => src.Quantity * src.SellingPrice)
            );
    }

    public void ProductCategoriesMap()
    {
        CreateMap<CategoryDto, ProductCategory>().ReverseMap();
        CreateMap<ProductCategory, CategoryResponse>();
    }
}
