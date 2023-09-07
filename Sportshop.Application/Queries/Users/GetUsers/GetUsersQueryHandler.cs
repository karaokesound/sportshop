using AutoMapper;
using MediatR;
using Sportshop.Application.Repositories;

namespace Sportshop.Application.Queries.Users.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetUsersQueryResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUsersQueryResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var usersEntity = await _userRepository.GetUsersAsync();

            var response = new List<GetUsersQueryResponse>();

            foreach (var user in usersEntity)
            {
                response.Add(_mapper.Map<GetUsersQueryResponse>(user));
            }

            return response;
        }
    }
}
