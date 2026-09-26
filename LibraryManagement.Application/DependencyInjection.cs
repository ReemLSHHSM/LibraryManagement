using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
          config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;
        }
    }
}
