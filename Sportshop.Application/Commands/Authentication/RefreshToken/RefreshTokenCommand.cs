using MediatR;
using Sportshop.API;

namespace Sportshop.Application.Commands.Authentication.RefreshToken
{
    public class RefreshTokenCommand : IRequest<TokenModel>
    {
        public string AccessToken { get; set; } = null!;

        public string RefreshToken { get; set; } = null!;
    }
}
