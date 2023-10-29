using Microsoft.AspNetCore.Http;
using Serilog;
using Sportshop.Application.Exceptions;
using Sportshop.Domain.Models;

namespace Sportshop.Application.Extensions
{
    public class GlobalExceptionsHandlingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public GlobalExceptionsHandlingMiddleware(ILogger logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            
            var errorDetails = exception switch
            {
                ExpiredRefreshTokenException => new ErrorModel(StatusCodes.Status405MethodNotAllowed, exception.Message),
                InvalidLoginDataException => new ErrorModel(StatusCodes.Status400BadRequest, exception.Message),
                InvalidRefreshTokenException => new ErrorModel(StatusCodes.Status405MethodNotAllowed, exception.Message),
                InvalidRegisterDataException => new ErrorModel(StatusCodes.Status400BadRequest, exception.Message),
                ProductNotFoundException => new ErrorModel(StatusCodes.Status404NotFound, exception.Message),
                ProductsNotFoundException => new ErrorModel(StatusCodes.Status404NotFound, exception.Message),
                UsersNotFoundException => new ErrorModel(StatusCodes.Status404NotFound, exception.Message),
                DatabaseStateException => new ErrorModel(StatusCodes.Status404NotFound, exception.Message),
            };

            _logger.Error(exception.Message);

            context.Response.StatusCode = errorDetails.StatusCode;
            await context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}
