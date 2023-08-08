using Microsoft.Extensions.DependencyInjection;
using NURBNB.Alojamiento.Domain.Factories;
using System.Reflection;

namespace NURBNB.Alojamiento.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicaction(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<IPaisFactory, PaisFactory>();
            services.AddSingleton<ICiudadFactory, CiudadFactory>();
            services.AddSingleton<IPropiedadFactory, PropiedadFactory>();
            return services;
        }
    }
}
