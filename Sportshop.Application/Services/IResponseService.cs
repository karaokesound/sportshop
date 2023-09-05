using Sportshop.Application.Dtos;
using Sportshop.Application.Dtos.Product;

namespace Sportshop.Application.Services
{
    public interface IResponseService
    {
        ProductForResponse ProductCreated(ProductDto product);
    }
}
