namespace Sportshop.Application.Commands.Authentication.CreateUser
{
    public class CreateUserCommandResponse
    {
        public string Message { get; set; } = null!;

        public Guid Id { get; set; }

        public string Username { get; set; } = null!;
    }
}
