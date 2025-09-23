using Azure.Identity;
using LibraryManagement.Core.Dto;
using System.Net;
using System.Text.Json;

namespace LibraryManagement.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred. Request: {Method} {Path}",
                context.Request.Method, context.Request.Path);

            context.Response.ContentType = "application/json";
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "An unexpected error occurred. Please try again later.";

            switch (exception)
            {
                
                case AuthenticationFailedException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                case ApplicationException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = "You are not authorized to perform this action.";
                    break;
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            var errorResponse = new ErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = message,
                Timestamp = DateTime.UtcNow
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }

}
