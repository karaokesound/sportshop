using AutoMapper;
using MediatR;
using Sportshop.Application.ReadModels.Responses;
using Sportshop.Application.Repositories;

namespace Sportshop.Application.Queries.Product
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponse?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductAsync(request.ProductId);

            return product == null ? null : _mapper.Map<ProductResponse>(product);
        }
    }
}
