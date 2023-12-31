﻿using MediatR;

namespace Sportshop.Application.Queries.Product.GetProduct
{
    public class GetProductQuery : IRequest<GetProductQueryResponse>
    {
        public Guid Id { get; }

        public GetProductQuery(Guid id)
        {
            Id = id;
        }
    }
}
