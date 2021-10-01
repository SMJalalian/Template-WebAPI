using System;
using System.Net;

namespace MyProject.Shared.Exceptions
{
    public class BadRequestException : AppException
    {
        public BadRequestException()
            : base(HttpStatusCode.BadRequest)
        {
        }
        public BadRequestException(string message)
            : base(HttpStatusCode.BadRequest, message)
        {
        }
        public BadRequestException(object additionalData)
            : base(HttpStatusCode.BadRequest, additionalData)
        {
        }
        public BadRequestException(string message, object additionalData)
            : base(HttpStatusCode.BadRequest, message, additionalData)
        {
        }
        public BadRequestException(string message, Exception exception)
            : base(HttpStatusCode.BadRequest, message, exception)
        {
        }
        public BadRequestException(string message, Exception exception, object additionalData)
            : base(HttpStatusCode.BadRequest, message, exception, additionalData)
        {
        }
    }
}
