using MediatR;
using Sportshop.API;
using System.ComponentModel.DataAnnotations;

namespace Sportshop.Application.Commands.Authentication.Login
{
    public class LoginCommand : IRequest<TokenModel>
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
