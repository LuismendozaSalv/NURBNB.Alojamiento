using Microsoft.Extensions.DependencyInjection;
using NURBNB.Alojamiento.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
