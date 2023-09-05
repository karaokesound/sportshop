using Sportshop.Application.Dtos;
using Sportshop.Application.Dtos.Product;

namespace Sportshop.Application.Services
{
    public class ResponseService : IResponseService
    {
        public ProductForResponse ProductCreated(ProductDto product)
        {
            var response = new ProductForResponse()
            {
                Message = "You've successfully created a new product! Details below:",
                Name = product.Name,
                Quantity = product.Quantity,
                Seller = product.Seller
            };

            return response;
        }
    }
}
