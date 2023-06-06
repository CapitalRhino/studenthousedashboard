using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Exceptions
{
    public class DatabaseOperationException : ApplicationException
    {
        public DatabaseOperationException(string? message) : base(message)
        {
        }

        public DatabaseOperationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
