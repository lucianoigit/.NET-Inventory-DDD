using Domain.Warehouses;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            });

            services.AddScoped<TransferService>(); // Aqui podria inyectar la interfaz y no la implementacion de la clase

            return services;
            
        }
    }
}
