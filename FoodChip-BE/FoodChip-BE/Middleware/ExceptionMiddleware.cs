using Application.Exceptions;
using Newtonsoft.Json;

namespace FoodChip_BE.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await SetErrorResponse(httpContext, e);
            }
        }

        private async Task SetErrorResponse(HttpContext context, Exception exception)
        {
            var statusCode = StatusCodes.Status500InternalServerError;
            CustomErrorResponse? customException = null;

            if (exception is ObjectNotFoundException)
            {
                customException = new CustomErrorResponse(exception);
                statusCode = StatusCodes.Status404NotFound;
            }
            else
            {
                customException = new CustomErrorResponse(exception);
            }

            context.Response.StatusCode = statusCode;

            if (customException == null)
            {
                await context.Response.CompleteAsync();
            }
            else
            {
                context.Response.ContentType = "application/json;charset=utf-8";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(customException));
            }
        }
    }
}
