using AutoMapper;
using PointOfSale.Api.Features.Users.Models;

namespace PointOfSale.Api.Features.Users.Contracts;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserResponse>()
            .ConstructUsing(src => new UserResponse(src.Id, src.Username, src.Email, src.Phone, src.ImgUrl, src.Active));

        CreateMap<UserDto, User>()
            .ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src => src.img_url));
    }
}