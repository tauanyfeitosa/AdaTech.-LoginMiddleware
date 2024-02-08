using System.Text.Json;

namespace AdaTech._LoginMiddleware.WebAPI.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var errorResponse = JsonSerializer.Serialize(new { Message = "Ocorreu um erro inesperado. Tente novamente mais tarde." });
                await context.Response.WriteAsync(errorResponse);
            }
        }
    }
}
