using AutoMapper;
using Sportshop.Application.Dtos;
using Sportshop.Domain.Entities;

namespace Sportshop.Application.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserEntity>();
        }
    }
}
