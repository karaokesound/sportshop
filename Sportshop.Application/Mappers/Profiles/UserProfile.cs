using AutoMapper;
using Sportshop.Application.Commands.Users.Register;
using Sportshop.Application.Queries.Users.GetUsers;
using Sportshop.Domain.Entities;

namespace Sportshop.Application.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // CreateUser
            CreateMap<RegisterUserCommand, UserEntity>();
            CreateMap<UserEntity, RegisterUserCommandResponse>();

            // GetUsers
            CreateMap<UserEntity, GetUsersQueryResponse>();
        }
    }
}
