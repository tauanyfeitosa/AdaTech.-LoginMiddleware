using System.Text.Json;

namespace AdaTech._LoginMiddleware.WebAPI.Utilities.Middleware
{
    public class QueryValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public QueryValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var query = context.Request.Query;

            // Validação para a ação Get byId, que espera um parâmetro de consulta 'id'
            if (context.Request.Path.Value.EndsWith("/byId", StringComparison.OrdinalIgnoreCase) &&
            (context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase) || context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase)))
            {
                if (!query.ContainsKey("id") || !int.TryParse(query["id"], out int _))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = "O parâmetro 'id' é obrigatório e deve ser um número inteiro." }));
                    return;
                }
            }

            // Validação para a ação PostLogin, que espera parâmetros de consulta 'login' e 'senha'
            if (context.Request.Path.Value.EndsWith("/login", StringComparison.OrdinalIgnoreCase) &&
                context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                if (!query.ContainsKey("login") || string.IsNullOrWhiteSpace(query["login"]) ||
                    !query.ContainsKey("senha") || string.IsNullOrWhiteSpace(query["senha"]))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = "Os parâmetros de consulta 'login' e 'senha' são obrigatórios." }));
                    return;
                }
            }

            // Validação para a ação PostLogout, que espera um parâmetro de consulta 'id'
            if (context.Request.Path.Value.EndsWith("/sair", StringComparison.OrdinalIgnoreCase) &&
                context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                if (!query.ContainsKey("id") || !int.TryParse(query["id"], out int id))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = "O parâmetro 'id' é obrigatório e deve ser um número inteiro." }));
                    return;
                }
            }

            await _next(context);
        }
    }
}
