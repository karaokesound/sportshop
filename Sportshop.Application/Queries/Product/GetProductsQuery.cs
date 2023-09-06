using MediatR;
using Sportshop.Application.ReadModels.Responses;

namespace Sportshop.Application.Queries.Product
{
    public class GetProductsQuery : IRequest<List<ProductResponse>>
    {
    }
}
