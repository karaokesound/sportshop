using MediatR;

namespace Sportshop.Application.Commands.Authentication.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
