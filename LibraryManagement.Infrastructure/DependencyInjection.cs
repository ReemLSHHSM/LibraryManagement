using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories;
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
    services.AddScoped<IBookRepository, BookRepository>();
    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    return services;
  }
}
