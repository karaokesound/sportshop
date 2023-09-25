using AutoMapper;
using MediatR;
using Sportshop.Application.Exceptions;
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

            if (usersEntity == null | usersEntity.Count == 0) throw new UsersNotFoundException(
                "There are no users in the database.");

            var response = new List<GetUsersQueryResponse>();

            foreach (var user in usersEntity)
            {
                response.Add(_mapper.Map<GetUsersQueryResponse>(user));
            }

            return response;
        }
    }
}
