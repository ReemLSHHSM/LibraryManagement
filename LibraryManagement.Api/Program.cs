using LibraryManagement.Application;
using LibraryManagement.Infrastructure;

namespace LibraryManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register our application layers
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            // Controllers
            builder.Services.AddControllers();

            // OpenAPI
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Development only
            if (app.Environment.IsDevelopment())
            {
                // Generate the OpenAPI document
                app.MapOpenApi();

                // Swagger UI
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(
                        "/openapi/v1.json",
                        "Library Management API"
                    );
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}