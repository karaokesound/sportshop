using Sportshop.Application.Commands.Products.CreateProduct;
using Sportshop.Domain.Models;

namespace Sportshop.Application.Services.Product
{
    public interface IProductService
    {
        Task<bool> ProductDataValidation(CreateProductCommand requestedProduct);

        Task<Guid> AppendThumbnailAndGetIdAsync(ThumbnailModel thumbnail, string productName);

        void DeleteThumbnail(Guid thumbnailId, string productName);
    }
}
