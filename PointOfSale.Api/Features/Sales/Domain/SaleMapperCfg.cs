using AutoMapper;
using PointOfSale.Api.Features.Sales.Contracts;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Features.Sales.Domain;

public class SaleMapperCfg: Profile
{
    public SaleMapperCfg()
    {
        SaleHeader();
    }

    public void SaleHeader()
    {
        CreateMap<Sale, SaleHeaderApi>()
            .ForMember(dest => dest.customer_id, opt => opt.MapFrom(src => src.Customer.Id))
            .ForMember(dest => dest.customer_name, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.user_id, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.user_name, opt => opt.MapFrom(src => src.User.Username))
            .ForMember(dest => dest.receipt_type, opt => opt.MapFrom(src => src.ReceiptType));
    }
}
