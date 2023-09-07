using AutoMapper;
using Sportshop.Application.Commands.Authentication.CreateUser;
using Sportshop.Application.Queries.Users.GetUsers;
using Sportshop.Domain.Entities;

namespace Sportshop.Application.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // CreateUser
            CreateMap<CreateUserCommand, UserEntity>();
            CreateMap<UserEntity, CreateUserCommandResponse>();

            // GetUsers
            CreateMap<UserEntity, GetUsersQueryResponse>();
        }
    }
}
