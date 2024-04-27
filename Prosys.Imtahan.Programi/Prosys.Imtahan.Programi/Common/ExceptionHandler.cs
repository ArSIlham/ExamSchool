using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;


namespace Prosys.Imtahan.Programi.Common
{
    public static class ExceptionHandler
    {
        public static ActionResult HandleApiException(ApiException exception)
        {
            var response = new ApiResponse<object>(exception.Message, exception.Data);
            switch (exception.HttpStatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                default:
                    return new ObjectResult(response);
            }
        }

        public static string GetApiExceptionResponse(ApiException exception)
        {
            var response = new ApiResponse<object>(exception.Message, exception.Data);

            return JsonConvert.SerializeObject(response);
        }
    }
}
