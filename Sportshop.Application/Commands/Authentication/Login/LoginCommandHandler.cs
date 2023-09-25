using MediatR;
using Sportshop.API;
using Sportshop.Application.Exceptions;
using Sportshop.Application.Repositories;
using Sportshop.Application.Services.Authentication;
using System.Security.Cryptography;

namespace Sportshop.Application.Commands.Authentication.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (!await UserDataValidation(request)) throw new InvalidLoginDataException(
                "Username or password is not correct.");

            var userEntity = await _userRepository.GetUserByNameAsync(request.Username!);

            string userToken = _jwtService.GenerateToken(userEntity);
            TokenModel newUserRefreshToken = _jwtService.GenerateRefreshToken(userEntity, userToken);

            await _userRepository.SaveChangesAsync();

            return new LoginCommandResponse()
            {
                Message = "You've logged in!",
                TokenModel = newUserRefreshToken
            };
        }

        private async Task<bool> UserDataValidation(LoginCommand requestedUser)
        {
            var dbUser = await _userRepository.GetUserByNameAsync(requestedUser.Username!);
            bool isPasswordValid = false;

            if (dbUser != null)
            {
                var hmac = new HMACSHA512(dbUser.PasswordSalt!);
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(requestedUser.Password!));

                isPasswordValid = computedHash.SequenceEqual(dbUser.PasswordHash!);
            }

            if (dbUser == null || !isPasswordValid) return false;

            return true;
        }
    }
}
