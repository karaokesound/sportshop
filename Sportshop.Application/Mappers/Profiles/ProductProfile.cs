using AutoMapper;
using Sportshop.Application.Commands.Products.CreateProduct;
using Sportshop.Application.Queries.Product.GetProduct;
using Sportshop.Domain.Entities;

namespace Sportshop.Application.Mappers.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, GetProductQueryResponse>();
            CreateMap<CreateProductCommand, ProductEntity>();
            CreateMap<ProductEntity, CreateProductCommandResponse>();

        }
    }
}
