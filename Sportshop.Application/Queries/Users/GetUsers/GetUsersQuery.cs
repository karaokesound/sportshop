using MediatR;

namespace Sportshop.Application.Queries.Users.GetUsers
{
    public class GetUsersQuery : IRequest<List<GetUsersQueryResponse>>
    {
    }
}
