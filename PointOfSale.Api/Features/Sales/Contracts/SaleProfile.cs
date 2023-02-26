using AutoMapper;
using PointOfSale.Api.Features.Sales.Models;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Features.Sales.Contracts;

public class SaleProfile : Profile
{
    public SaleProfile()
    {
        CreateMap<Sale, SaleResponse>()
            .ForMember(dest => dest.customer, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.user, opt => opt.MapFrom(src => src.User.Username))
            .ForMember(dest => dest.receipt_type, opt => opt.MapFrom(src => src.TipoComprobante));
        
        CreateMap<SaleItem, SaleItemDto>()
            .ForMember(dest => dest.product_id, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.product_name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.selling_price, opt => opt.MapFrom(src => src.PrecioVenta))
            .ForMember(dest => dest.ammount, opt => opt.MapFrom(src => src.Quantity * src.PrecioVenta));
    }
}