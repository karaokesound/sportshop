namespace Sportshop.Application.Exceptions
{
    public class DatabaseStateException : Exception
    {
        public DatabaseStateException(string message) : base(message)
        {
        }
    }
}
