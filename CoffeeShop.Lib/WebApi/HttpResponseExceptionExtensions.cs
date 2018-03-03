namespace CoffeeShop.Lib.WebApi
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public static class HttpResponseExceptionExtensions
    {
        #region Public Methods and Operators

        public static void ThrowHttpErrorResponse(this HttpRequestMessage request, string message)
        {
            throw new HttpResponseException(
                request.CreateErrorResponse(HttpStatusCode.InternalServerError, message)
                );
        }

        public static void ThrowHttpErrorResponse(this HttpRequestMessage request, string message, HttpStatusCode httpStatusCode)
        {
            throw new HttpResponseException(
                request.CreateErrorResponse(httpStatusCode, message)
                );
        }

        #endregion
    }
}
