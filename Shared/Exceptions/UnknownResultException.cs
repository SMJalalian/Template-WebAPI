using System;
using System.Net;

namespace MyProject.Shared.Exceptions
{
    public class UnknownResultException : AppException
    {
        public UnknownResultException()
            : base(HttpStatusCode.InternalServerError)
        {
        }
        public UnknownResultException(string message)
            : base(HttpStatusCode.InternalServerError, message)
        {
        }
        public UnknownResultException(object additionalData)
            : base(HttpStatusCode.InternalServerError, additionalData)
        {
        }
        public UnknownResultException(string message, object additionalData)
            : base(HttpStatusCode.InternalServerError, message, additionalData)
        {
        }
        public UnknownResultException(string message, Exception exception)
            : base(HttpStatusCode.InternalServerError, message, exception)
        {
        }
        public UnknownResultException(string message, Exception exception, object additionalData)
            : base(HttpStatusCode.InternalServerError, message, exception, additionalData)
        {
        }
    }
}
