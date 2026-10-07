using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Handlers;
using LibraryManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(
      this IServiceCollection services,
      IConfiguration configuration)
  {
    services.AddDbContext<LibraryDbContext>(options =>
        options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection")));

    //this tells the DI container to use already registered LibraryDbContext whenever ILibraryDbContext is requested
    services.AddScoped<ILibraryDbContext>(
        provider => provider.GetRequiredService<LibraryDbContext>()
    );

    //Http client configuration
    services.AddHttpClient("LibraryApi", client =>
    {
      client.BaseAddress = new Uri(
          configuration["ExternalApis:LibraryApiBaseUrl"]!);
    }).AddHttpMessageHandler<AuthHeaderHandler>();

    services.AddScoped<IExternalBookService, ExternalBookService>();
    services.AddScoped<IExternalAuthService, ExternalAuthService>();


    services.AddSingleton<ITokenProvider, TokenProvider>();

    services.AddTransient<AuthHeaderHandler>();

    //services.AddRefitClient<ILibraryApi>()
    //.ConfigureHttpClient(client =>
    //{
    //  client.BaseAddress = new Uri(
    //      configuration["ExternalApis:LibraryApiBaseUrl"]!);
    //});

    //services.AddScoped<IExternalBookService, RefitExternalBookService>();

    return services;
  }
}
