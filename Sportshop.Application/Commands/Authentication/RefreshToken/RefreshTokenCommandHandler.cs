using MediatR;
using Sportshop.API;
using Sportshop.Application.Repositories;
using Sportshop.Application.Services.Authentication;

namespace Sportshop.Application.Commands.Authentication.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public RefreshTokenCommandHandler(IUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<TokenModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetUserByRefreshToken(request.RefreshToken);

            if (userEntity == null
                || !userEntity.RefreshToken.Equals(request.RefreshToken))
            {
                return null!;
            }
            else if (userEntity.TokenExpires < DateTime.Now)
            {
                return null!;
            }

            string userToken = _jwtService.GenerateToken(userEntity);
            TokenModel newUserRefreshToken = _jwtService.GenerateRefreshToken(userEntity, userToken);

            await _userRepository.SaveChangesAsync();

            return newUserRefreshToken;
        }
    }
}
