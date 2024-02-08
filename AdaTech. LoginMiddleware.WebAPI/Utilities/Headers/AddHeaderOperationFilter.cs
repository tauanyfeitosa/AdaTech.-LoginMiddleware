using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AdaTech._LoginMiddleware.WebAPI.Utilities.Headers
{
    public class AddHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var verificar = context.ApiDescription.RelativePath.Equals("api/login", StringComparison.OrdinalIgnoreCase)
                                    || context.ApiDescription.RelativePath.Equals("api/registro", StringComparison.OrdinalIgnoreCase);

            if (!verificar)
            {
                operation.Parameters ??= new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "UsuarioLogadoId",
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "int"
                    }
                });
            }
        }
    }
}
