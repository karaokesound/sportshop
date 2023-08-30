using AutoMapper;
using Sportshop.Application.Repositories;

namespace Sportshop.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void CreateUser()
        {
            var guid = Guid.NewGuid();
            _userRepository.DeleteUser(guid);
        }
    }
}
