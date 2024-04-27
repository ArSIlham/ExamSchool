using System.Net;

namespace Prosys.Imtahan.Programi.Common
{
    public class ApiException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public object Data { get; set; }

        public ApiException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public ApiException(string message, HttpStatusCode httpStatusCode, object data) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            Data = data;
        }
    }
}
