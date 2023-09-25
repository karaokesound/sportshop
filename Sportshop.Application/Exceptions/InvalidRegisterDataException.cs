namespace Sportshop.Application.Exceptions
{
    public class InvalidRegisterDataException : Exception
    {
        public InvalidRegisterDataException(string message) : base(message)
        {
        }
    }
}
