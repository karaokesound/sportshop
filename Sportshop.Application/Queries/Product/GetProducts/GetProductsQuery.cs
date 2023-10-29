using MediatR;
using Sportshop.Application.Queries.Product.GetProduct;

namespace Sportshop.Application.Queries.Product.GetProducts
{
    public class GetProductsQuery : IRequest<List<GetProductQueryResponse>>
    {
        public int Page { get; set; }
        public int NumberOfProductsToTake { get; set; }

        public GetProductsQuery(int page, int numberOfItemsToTake)
        {
            Page = page;
            NumberOfProductsToTake = numberOfItemsToTake;
        }
    }
}
