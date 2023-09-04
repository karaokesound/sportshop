using Sportshop.Application.Dtos;
using Sportshop.Domain.Models;

namespace Sportshop.API.Services
{
    public interface IProductControllerService
    {
        Task AddProduct(ProductDto requestedProduct, Thumbnail productThumbnail);

        Task<bool> ProductDataValidation(ProductDto requestedProduct);
    }
}
