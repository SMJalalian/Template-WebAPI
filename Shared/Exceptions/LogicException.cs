using System;
using System.Net;

namespace MyProject.Shared.Exceptions
{
    public class LogicException : AppException
    {
        public LogicException()
            : base(HttpStatusCode.Conflict)
        {
        }
        public LogicException(string message)
            : base(HttpStatusCode.Conflict, message)
        {
        }
        public LogicException(object additionalData)
            : base(HttpStatusCode.Conflict, additionalData)
        {
        }
        public LogicException(string message, object additionalData)
            : base(HttpStatusCode.Conflict, message, additionalData)
        {
        }
        public LogicException(string message, Exception exception)
            : base(HttpStatusCode.Conflict, message, exception)
        {
        }
        public LogicException(string message, Exception exception, object additionalData)
            : base(HttpStatusCode.Conflict, message, exception, additionalData)
        {
        }
    }
}
