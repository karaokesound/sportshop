using AutoMapper;
using MediatR;
using Sportshop.Application.Exceptions;
using Sportshop.Application.Repositories;

namespace Sportshop.Application.Queries.Product.GetDatabaseState
{
    public class GetDatabaseStateQueryHandler : IRequestHandler<GetDatabaseStateQuery, GetDatabaseStateQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetDatabaseStateQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetDatabaseStateQueryResponse> Handle(GetDatabaseStateQuery request, CancellationToken cancellationToken)
        {
            var databaseState = await _productRepository.GetDatabaseState();

            if (databaseState == 0)
                throw new DatabaseStateException("The database is empty.");

            return new GetDatabaseStateQueryResponse()
            {
                NumberOfItems = databaseState
            };
        }
    }
}
