using AutoMapper;
using MediatR;
using Sportshop.Application.ReadModels.Responses;
using Sportshop.Application.Repositories;

namespace Sportshop.Application.Queries.Product
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsAsync();
            var mappedProducts = new List<ProductResponse>();

            foreach (var product in products)
            {
                mappedProducts.Add(_mapper.Map<ProductResponse>(product));
            }

            return mappedProducts;
        }
    }
}
