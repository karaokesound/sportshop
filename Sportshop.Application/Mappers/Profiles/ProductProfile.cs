using AutoMapper;
using Sportshop.Application.Commands.Products.CreateProduct;
using Sportshop.Application.Commands.Products.UpdateProduct;
using Sportshop.Application.Queries.Product.GetProduct;
using Sportshop.Domain.Entities;

namespace Sportshop.Application.Mappers.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // GetProduct
            CreateMap<ProductEntity, GetProductQueryResponse>();

            // CreateProduct
            CreateMap<CreateProductCommand, ProductEntity>();
            CreateMap<ProductEntity, CreateProductCommandResponse>();

            // UpdateProduct
            CreateMap<UpdateProductCommand, ProductEntity>();
        }
    }
}
