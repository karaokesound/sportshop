using Sportshop.API;

namespace Sportshop.Application.Commands.Authentication.Login
{
    public class LoginCommandResponse
    {
        public string Message { get; set; } = null!;

        public TokenModel TokenModel { get; set; } = null!;
    }
}
