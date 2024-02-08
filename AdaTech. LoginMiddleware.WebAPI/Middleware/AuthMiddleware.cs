﻿using AdaTech._LoginMiddleware.WebAPI.Data;
using System.Text.Json;

namespace AdaTech._LoginMiddleware.WebAPI.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/Usuario/login") ||
            context.Request.Path.StartsWithSegments("/api/Usuario/registro"))
            {
                await _next(context);
                return;
            }

            if (!int.TryParse(context.Request.Query["id"], out int id))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = "O parâmetro 'id' é obrigatório e deve ser um número inteiro." }));
                return;
            }

            var usuario = DataEntity.Usuarios.FirstOrDefault(u => u.Id == id && u.Is_logado);

            if (usuario != null)
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = "Acesso não autorizado. Usuário deve estar logado." }));
            }
        }
    }
}
