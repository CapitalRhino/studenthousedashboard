using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
