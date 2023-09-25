using AutoMapper;
using MediatR;
using Sportshop.Application.Exceptions;
using Sportshop.Application.Repositories;
using Sportshop.Domain.Entities;
using System.Security.Cryptography;

namespace Sportshop.Application.Commands.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await UserExists(request)) throw new InvalidRegisterDataException(
                "This username is being used by another user. Try with another one.");

            CreatePasswordHash(request.Password!, out byte[] passwordHash, out byte[] passwordSalt);

            var userEntity = _mapper.Map<UserEntity>(request);
            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;

            await _userRepository.CreateUserAsync(userEntity);
            await _userRepository.SaveChangesAsync();

            return new RegisterUserCommandResponse()
            {
                Message = "You've created a new account!",
                Id = userEntity.Id,
                Username = userEntity.Username
            };
        }

        private async Task<bool> UserExists(RegisterUserCommand requestedUser)
        {
            bool usernameExists = await _userRepository.GetUserByNameAsync(requestedUser.Username!) 
                != null ? true : false;

            if (usernameExists) return true;

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
