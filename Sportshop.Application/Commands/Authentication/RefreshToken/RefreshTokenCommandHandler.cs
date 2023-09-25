using MediatR;
using Sportshop.API;
using Sportshop.Application.Exceptions;
using Sportshop.Application.Repositories;
using Sportshop.Application.Services.Authentication;

namespace Sportshop.Application.Commands.Authentication.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public RefreshTokenCommandHandler(IUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetUserByRefreshToken(request.RefreshToken);

            if (userEntity == null
                || !userEntity.RefreshToken.Equals(request.RefreshToken))
            {
                throw new InvalidRefreshTokenException("Your token is invalid.");
            }
            else if (userEntity.TokenExpires < DateTime.Now)
            {
                throw new ExpiredRefreshTokenException("Your token has expired.");
            }

            string userToken = _jwtService.GenerateToken(userEntity);
            TokenModel newUserRefreshToken = _jwtService.GenerateRefreshToken(userEntity, userToken);

            await _userRepository.SaveChangesAsync();

            return new RefreshTokenCommandResponse()
            {
                Message = "New refresh token is generated.",
                TokenModel = newUserRefreshToken
            };
        }
    }
}
