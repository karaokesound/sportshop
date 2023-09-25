using AutoMapper;
using MediatR;
using Sportshop.Application.Exceptions;
using Sportshop.Application.Queries.Product.GetProduct;
using Sportshop.Application.Repositories;

namespace Sportshop.Application.Queries.Product.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductQueryResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductQueryResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsAsync();

            if (products == null || products.Count == 0) throw new ProductsNotFoundException(
                "There are no products in the database.");

            var mappedProducts = new List<GetProductQueryResponse>();

            foreach (var product in products)
            {
                mappedProducts.Add(_mapper.Map<GetProductQueryResponse>(product));
            }

            return mappedProducts;
        }
    }
}
