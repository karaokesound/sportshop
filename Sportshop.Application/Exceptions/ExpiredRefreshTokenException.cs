namespace Sportshop.Application.Exceptions
{
    public class ExpiredRefreshTokenException : Exception
    {
        public ExpiredRefreshTokenException(string message) : base(message)
        {
        }
    }
}
