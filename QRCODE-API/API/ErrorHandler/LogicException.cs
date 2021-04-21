using System;
using System.Net;

namespace QRCODE_API.ErrorHandler
{
    public class LogicException : Exception
    {
        public HttpStatusCode statusCode;
        public ErrorCode errorCode { get; set; }

        public LogicException() : this(HttpStatusCode.InternalServerError, ErrorCode.Unhandled)
        {
        }

        public LogicException(HttpStatusCode statusCode, ErrorCode errorCode)
        {
            this.statusCode = statusCode;
            this.errorCode = errorCode;
        }
    }
}
