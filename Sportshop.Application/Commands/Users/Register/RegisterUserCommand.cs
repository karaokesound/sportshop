using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Sportshop.Application.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<RegisterUserCommandResponse>
    {
        [Required]
        [MaxLength(25)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(25)]
        public string Password { get; set; } = null!;

        [MaxLength(25)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(25)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(25)]
        public string City { get; set; } = null!;

        [Required]
        [Range(18, 50, ErrorMessage = "Age must be between 18 and 99.")]
        public int Age { get; set; }
    }
}
