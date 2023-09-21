using MediatR;

namespace Sportshop.Application.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<RegisterUserCommandResponse>
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string City { get; set; } = null!;

        public int Age { get; set; }
    }
}
