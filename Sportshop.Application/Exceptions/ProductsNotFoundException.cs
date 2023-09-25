namespace Sportshop.Application.Exceptions
{
    public class ProductsNotFoundException : Exception
    {
        public ProductsNotFoundException(string message) : base(message)
        {
        }
    }
}
