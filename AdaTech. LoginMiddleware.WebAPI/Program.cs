using AdaTech._LoginMiddleware.WebAPI.Utilities.Headers;
using AdaTech._LoginMiddleware.WebAPI.Utilities.Middleware;
using Microsoft.OpenApi.Models;

namespace AdaTech._LoginMiddleware.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "LoginMiddleware", Version = "v1" });
                options.OperationFilter<AddHeaderParameterOperationFilter>();
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseMiddleware<QueryValidationMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<AuthMiddleware>();


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
