using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var numberOfProductsToSkip = await ReturnsNumberOfProductsToSkip(
                request.Page, request.NumberOfProductsToTake);

            var products = await _productRepository.GetProductsAsync(request.NumberOfProductsToTake, numberOfProductsToSkip);

            if (products == null || products.Count == 0)
                return null!;
                    // logger, zalogować błąd

            var mappedProducts = new List<GetProductQueryResponse>();

            foreach (var product in products)
            {
                mappedProducts.Add(_mapper.Map<GetProductQueryResponse>(product));
            }

            return mappedProducts;
        }

        private async Task<int> ReturnsNumberOfProductsToSkip(int page, int numberOfProductsToTake)
        {
            int numberOfProductsToSkip = 0;

            int databaseItemsQuantity = await _productRepository.GetDatabaseState();
            decimal numberOfPages = Math.Ceiling((decimal)databaseItemsQuantity / (decimal)numberOfProductsToTake);

            if (page > 1 && page < numberOfPages)
            {
                numberOfProductsToSkip = (page - 1) * numberOfProductsToTake;
            }

            if (page == numberOfPages)
            {
                numberOfProductsToSkip = (page - 1) * numberOfProductsToTake;
            }

            return numberOfProductsToSkip;
        }
    }
}
