using MediatR;
using Sportshop.Application.ReadModels.Responses;

namespace Sportshop.Application.Queries.Product
{
    public class GetProductQuery : IRequest<ProductResponse>
    {
        public Guid ProductId { get; }

        public GetProductQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
