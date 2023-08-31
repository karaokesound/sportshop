using AutoMapper;
using Sportshop.Application.Dtos;
using Sportshop.Domain.Entities;
using Sportshop.Domain.Models;

namespace Sportshop.Application.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<User, UserEntity>();
        }
    }
}
