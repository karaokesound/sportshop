using AutoMapper;
using Sportshop.Application.ReadModels.Dtos.Authentication;
using Sportshop.Domain.Entities;
using Sportshop.Domain.Models;

namespace Sportshop.Application.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserModel>();
            CreateMap<UserModel, UserDto>();
            CreateMap<UserModel, UserEntity>();
            CreateMap<UserForLoginDto, UserDto>();
        }
    }
}
