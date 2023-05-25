using AutoMapper;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Features.Sales.Contracts;

namespace PointOfSale.Api.Application.Mappings;

public class SaleMappings : Profile
{
    public SaleMappings()
    {
        SaleHeaderMap();
        SaleItemMap();
    }

    public void SaleHeaderMap()
    {
        CreateMap<Sale, SaleHeaderApi>()
            .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.DateTime))
            .ForMember(dest => dest.customer_id, opt => opt.MapFrom(src => src.Customer.Id))
            .ForMember(dest => dest.customer_name, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.user_id, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.user_name, opt => opt.MapFrom(src => src.User.Username))
            .ForMember(dest => dest.receipt_type, opt => opt.MapFrom(src => src.ReceiptType));
    }

    public void SaleItemMap()
    {
        CreateMap<SaleItem, SaleItemApi>()
            .ForMember(dest => dest.product_id, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.product_name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.selling_price, opt => opt.MapFrom(src => src.SellingPrice))
            .ForMember(dest => dest.tax, opt => opt.MapFrom(src => src.Tax))
            .ForMember(dest => dest.ammount, opt => opt.MapFrom(src => src.Total));
    }
}
