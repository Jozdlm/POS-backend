using AutoMapper;
using PointOfSale.Api.Domain.Entities;
using PointOfSale.Api.Features.Sales.Contracts;

namespace PointOfSale.Api.Application.Mappings;

public class SaleMappings : Profile
{
    public SaleMappings()
    {
       SaleItemMap();
    }

    public void SaleItemMap ()
    {
        CreateMap<SaleItem, SaleItemApi>()
            .ForMember(dest => dest.product_id, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.product_name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.selling_price, opt => opt.MapFrom(src => src.SellingPrice))
            .ForMember(dest => dest.tax, opt => opt.MapFrom(src => src.Tax))
            .ForMember(dest => dest.ammount, opt => opt.MapFrom(src => src.Total));
    }
}