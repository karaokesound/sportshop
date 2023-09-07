using MediatR;
using Sportshop.Application.Queries.Product.GetProduct;

namespace Sportshop.Application.Queries.Product.GetProducts
{
    public class GetProductsQuery : IRequest<List<GetProductQueryResponse>>
    {
    }
}
