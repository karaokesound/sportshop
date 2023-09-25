using MediatR;
using Sportshop.API;

namespace Sportshop.Application.Commands.Authentication.RefreshToken
{
    public class RefreshTokenCommandResponse
    {
        public string Message { get; set; } = null!;

        public TokenModel TokenModel { get; set; }
    }
}
