namespace Sportshop.Application.Exceptions
{
    public class InvalidLoginDataException : Exception
    {
        public InvalidLoginDataException(string message) : base(message)
        {
        }
    }
}
