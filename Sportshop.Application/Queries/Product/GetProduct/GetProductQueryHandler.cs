using AutoMapper;
using MediatR;
using Sportshop.Application.Repositories;

namespace Sportshop.Application.Queries.Product.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductQueryResponse?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var productEntity = await _productRepository.GetProductAsync(request.ProductId);

            return productEntity == null ? null : _mapper.Map<GetProductQueryResponse>(productEntity);
        }
    }
}
