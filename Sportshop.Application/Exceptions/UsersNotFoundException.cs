namespace Sportshop.Application.Exceptions
{
    public class UsersNotFoundException : Exception
    {
        public UsersNotFoundException(string message) : base(message)
        {
        }
    }
}
