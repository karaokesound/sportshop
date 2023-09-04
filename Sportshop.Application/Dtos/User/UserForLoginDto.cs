using System.ComponentModel.DataAnnotations;

namespace Sportshop.Application.Dtos.User
{
    public class UserForLoginDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
