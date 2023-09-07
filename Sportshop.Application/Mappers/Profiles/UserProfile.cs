using AutoMapper;
using Sportshop.Application.Commands.Authentication.CreateUser;
using Sportshop.Domain.Entities;

namespace Sportshop.Application.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, UserEntity>();
            CreateMap<UserEntity, CreateUserCommandResponse>();
        }
    }
}
