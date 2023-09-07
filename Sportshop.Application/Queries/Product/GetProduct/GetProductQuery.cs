using MediatR;

namespace Sportshop.Application.Queries.Product.GetProduct
{
    public class GetProductQuery : IRequest<GetProductQueryResponse>
    {
        public Guid ProductId { get; }

        public GetProductQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
