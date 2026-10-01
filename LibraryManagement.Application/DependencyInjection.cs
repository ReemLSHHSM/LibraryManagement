using FluentValidation;
using LibraryManagement.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Application
{
  public static class DependencyInjection
  {

    public static IServiceCollection AddApplication(
        this IServiceCollection services
        )
    {
      // Register application services here
      services.AddMediatR(config =>
      {
        config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

        config.AddOpenBehavior(
            typeof(ValidationBehavior<,>)
        );
      }
    );

      services.AddValidatorsFromAssembly(
          typeof(DependencyInjection).Assembly
      ); return services;
    }
  }
}
