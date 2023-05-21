using AutoMapper;
using PointOfSale.Api.Application.Contracts;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Features.Products.Contracts;

namespace PointOfSale.Api.Application.Mappings;

public class ProductMappings : Profile
{
    public ProductMappings()
    {
        ProductMap();
        ProductKardexMap();
        ProductCategoriesMap();
    }

    public void ProductMap()
    {
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

    public void ProductKardexMap()
    {
        CreateMap<PurchaseItem, ProductKardex>()
            .ForMember(dest => dest.item_id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.operation_type, opt => opt.MapFrom(src => "Compra"))
            .ForMember(dest => dest.document_num, opt => opt.MapFrom(src => src.Purchase.DocumentNumber))
            .ForMember(dest => dest.date_time, opt => opt.MapFrom(src => src.Purchase.DateTime))
            .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(
                dest => dest.value,
                opt => opt.MapFrom(src => src.Quantity * src.PurchasePrice)
            );

        CreateMap<SaleItem, ProductKardex>()
            .ForMember(dest => dest.item_id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.operation_type, opt => opt.MapFrom(src => "Venta"))
            .ForMember(dest => dest.document_num, opt => opt.MapFrom(src => src.Sale.Id))
            .ForMember(dest => dest.date_time, opt => opt.MapFrom(src => src.Sale.DateTime))
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
