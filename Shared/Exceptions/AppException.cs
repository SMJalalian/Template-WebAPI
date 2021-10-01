using System;
using System.Net;

namespace MyProject.Shared.Exceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public object AdditionalData { get; set; }

        public AppException()
            : this(HttpStatusCode.InternalServerError)
        {
        }
        public AppException(string message)
            : this(HttpStatusCode.InternalServerError, message)
        {
        }
        public AppException(string message, object additionalData)
            : this(HttpStatusCode.InternalServerError, message, additionalData)
        {
        }
        public AppException(string message, Exception exception)
    : this(HttpStatusCode.InternalServerError, message, exception)
        {
        }
        public AppException(string message, Exception exception, object additionalData)
            : this(HttpStatusCode.InternalServerError, message, exception, additionalData)
        {
        }
        public AppException(HttpStatusCode httpStatusCode)
            : this(httpStatusCode, null)
        {
        }
        public AppException(HttpStatusCode httpStatusCode, object additionalData)
            : this(httpStatusCode, null, additionalData)
        {
        }
        public AppException(HttpStatusCode httpStatusCode, string message)
            : this(httpStatusCode, message, null)
        {
        }
        public AppException(HttpStatusCode httpStatusCode, string message, object additionalData)
            : this(httpStatusCode, message, null, additionalData)
        {
        }
        public AppException(HttpStatusCode httpStatusCode, string message, Exception exception)
            : this(httpStatusCode, message, exception, null)
        {
        }
        public AppException(HttpStatusCode httpStatusCode, string message, Exception exception, object additionalData)
            : base(message, exception)
        {
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
        }
    }
}
