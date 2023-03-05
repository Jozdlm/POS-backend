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
            .ForMember(dest => dest.receipt_type, opt => opt.MapFrom(src => src.ReceiptType));

        CreateMap<SaleHeaderDto, Sale>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.customer_id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.user_id))
            .ForMember(dest => dest.ReceiptType, opt => opt.MapFrom(src => src.receipt_type))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status_id));
        
        CreateMap<SaleItem, SaleItemApi>()
            .ForMember(dest => dest.product_id, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.product_name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.selling_price, opt => opt.MapFrom(src => src.SellingPrice))
            .ForMember(dest => dest.ammount, opt => opt.MapFrom(src => src.Quantity * src.SellingPrice));
    }
}