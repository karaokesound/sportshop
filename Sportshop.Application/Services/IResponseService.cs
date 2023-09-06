using Sportshop.Application.ReadModels.Dtos.Product;
using Sportshop.Application.ReadModels.Responses;

namespace Sportshop.Application.Services
{
    public interface IResponseService
    {
        ProductResponse ProductCreated(ProductDto product);
    }
}
