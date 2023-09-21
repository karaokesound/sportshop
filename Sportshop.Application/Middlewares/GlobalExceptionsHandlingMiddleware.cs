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
                RegisterErrorException => new ErrorModel(context.Response.StatusCode.ToString(), exception.Message)
            };

            _logger.Error(exception.Message);

            context.Response.StatusCode = int.Parse(errorDetails.FieldName);
            await context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}
