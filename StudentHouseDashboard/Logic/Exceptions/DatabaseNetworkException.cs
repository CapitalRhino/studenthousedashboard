using System.Net;

namespace Logic.Exceptions
{
    public class DatabaseNetworkException : WebException
    {
        public DatabaseNetworkException(string? message) : base(message)
        {
        }

        public DatabaseNetworkException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
