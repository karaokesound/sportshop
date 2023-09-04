using AutoMapper;
using Sportshop.Application.Dtos;
using Sportshop.Domain.Entities;
using Sportshop.Domain.Models;

namespace Sportshop.Application.Mappers.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<ProductDto, ProductEntity>();
        }
    }
}
