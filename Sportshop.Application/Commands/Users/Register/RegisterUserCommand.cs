using MediatR;

namespace Sportshop.Application.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<RegisterUserCommandResponse>
    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? City { get; set; }

        public int Age { get; set; }
    }
}
