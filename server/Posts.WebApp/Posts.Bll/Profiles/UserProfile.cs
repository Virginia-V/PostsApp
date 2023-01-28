using AutoMapper;
using Posts.Common.Dtos;
using Posts.Domain;

namespace Posts.Bll.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
            CreateMap<Geo, GeoDto>();
            CreateMap<GeoDto, Geo>();
            CreateMap<CreateUserDto, User>();
        }
    }
}
