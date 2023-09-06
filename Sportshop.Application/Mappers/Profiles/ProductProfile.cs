using AutoMapper;
using Sportshop.Application.Commands.Products;
using Sportshop.Application.ReadModels.Responses;
using Sportshop.Domain.Entities;
using Sportshop.Domain.Models;

namespace Sportshop.Application.Mappers.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductResponse>();
            CreateMap<CreateProductCommand, ProductEntity>();

        }
    }
}
