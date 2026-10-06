using LibraryManagement.Api.Filters;
using LibraryManagement.Application;
using LibraryManagement.Infrastructure;
using System.Text.Json.Serialization;

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

      builder.Services
          .AddControllers()
          .AddJsonOptions(options =>
          {
            options.JsonSerializerOptions.Converters.Add(
          new JsonStringEnumConverter());
          });

      builder.Services.ConfigureHttpJsonOptions(options =>
{
  options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict;
});

      builder.Services.AddScoped<RequestLoggingFilter>();
      builder.Services.AddOpenApi();

      var app = builder.Build();

      if (app.Environment.IsDevelopment())
      {
        app.MapOpenApi();

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
