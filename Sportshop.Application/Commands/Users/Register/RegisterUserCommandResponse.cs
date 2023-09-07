namespace Sportshop.Application.Commands.Users.Register
{
    public class RegisterUserCommandResponse
    {
        public string Message { get; set; } = null!;

        public Guid Id { get; set; }

        public string Username { get; set; } = null!;
    }
}
