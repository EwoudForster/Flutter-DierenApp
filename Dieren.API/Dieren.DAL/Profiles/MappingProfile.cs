using AutoMapper;
using Dieren.DAL.Dtos;
using Dieren.DAL.Models;

namespace Dieren.DAL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Dier
            CreateMap<Dier, DierDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));

            CreateMap<DierDto, Dier>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));

            // Map User
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Dieren, opt => opt.MapFrom(src => src.Dieren));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Dieren, opt => opt.MapFrom(src => src.Dieren));
        }
    }
}
