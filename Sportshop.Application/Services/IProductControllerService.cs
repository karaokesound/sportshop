using Sportshop.Application.Dtos;
using Sportshop.Domain.Models;

namespace Sportshop.Application.Services
{
    public interface IProductControllerService
    {
        Task AddProduct(ProductDto requestedProduct, Thumbnail productThumbnail);

        Task<bool> ProductDataValidation(ProductDto requestedProduct);
    }
}
