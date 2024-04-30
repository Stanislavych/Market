using Microsoft.Extensions.DependencyInjection;

namespace Market.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration=>configuration.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}
