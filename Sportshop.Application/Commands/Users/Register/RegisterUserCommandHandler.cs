using AutoMapper;
using MediatR;
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
            if (!await UserDataValidation(request, 0)) return null;

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var userEntity = _mapper.Map<UserEntity>(request);
            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;

            await _userRepository.CreateUserAsync(userEntity);
            await _userRepository.SaveChangesAsync();

            var response = _mapper.Map<RegisterUserCommandResponse>(userEntity);
            response.Message = "Success!";

            return response;
        }

        private async Task<bool> UserDataValidation(RegisterUserCommand requestedUser, int operationValue)
        {
            switch (operationValue)
            {
                case 0: // Registration
                    bool usernameExists = await _userRepository.GetUserByNameAsync(requestedUser.Username) != null ? true : false;

                    if (usernameExists) return false;
                    break;

                case 1: // Login
                    var dbUser = await _userRepository.GetUserByNameAsync(requestedUser.Username);
                    bool passwordValidation = false;

                    if (dbUser != null)
                    {
                        var hmac = new HMACSHA512(dbUser.PasswordSalt!);
                        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(requestedUser.Password));

                        passwordValidation = computedHash.SequenceEqual(dbUser.PasswordHash!);
                    }

                    if (dbUser == null || !passwordValidation) return false;
                    break;
            }

            return true;
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
