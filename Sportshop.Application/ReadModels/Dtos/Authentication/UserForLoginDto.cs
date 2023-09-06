using System.ComponentModel.DataAnnotations;

namespace Sportshop.Application.ReadModels.Dtos.Authentication
{
    public class UserForLoginDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
