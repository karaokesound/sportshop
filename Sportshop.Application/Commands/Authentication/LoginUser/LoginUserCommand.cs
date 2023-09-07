using MediatR;
using Sportshop.API;
using System.ComponentModel.DataAnnotations;

namespace Sportshop.Application.Commands.Authentication.LoginUser
{
    public class LoginUserCommand : IRequest<TokenModel>
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
