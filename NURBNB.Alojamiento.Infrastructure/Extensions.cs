using Consul;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NURBNB.Alojamiento.Application;
using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Application.Services;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Infrastructure.Consul;
using NURBNB.Alojamiento.Infrastructure.EF;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using NURBNB.Alojamiento.Infrastructure.EF.Repositories;
using NURBNB.Alojamiento.Infrastructure.MassTransit;
using NURBNB.Alojamiento.Infrastructure.MassTransit.Consumers;
using Restaurant.SharedKernel.Core;
using System.IO;
using System.Reflection;
using static System.Formats.Asn1.AsnWriter;

namespace NURBNB.Alojamiento.Infrastructure
{
	public static class Extensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
		{
			services.AddApplicaction();
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddConsulConfig(configuration);
			AddDatabase(services, configuration, isDevelopment);
			AddMassTransitWithRabbitMq(services, configuration);
			return services;
		}

		private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
		{
			services.AddApplicaction();
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			var connectionString =
					configuration.GetConnectionString("AlojamientoDbConnectionString");
			services.AddDbContext<ReadDbContext>(context =>
					context.UseSqlServer(connectionString));
			services.AddDbContext<WriteDbContext>(context =>
				context.UseSqlServer(connectionString));

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IPaisRepository, PaisRepository>();
			services.AddScoped<ICiudadRepository, CiudadRepository>();
			services.AddScoped<IPropiedadRepository, PropiedadRepository>();
			services.AddScoped<IComodidadRepository, ComodidadRepository>();
			services.AddScoped<IDireccionRepository, DireccionRepository>();
			services.AddScoped<IPropiedadComodidadRepository, PropiedadComodidadRepository>();

			using var scope = services.BuildServiceProvider().CreateScope();
			if (!isDevelopment)
			{
				var context = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
				context.Database.Migrate();
			}

			var readContext = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
			if (!readContext.Database.GetPendingMigrations().Any() &&
				readContext.Database.GetMigrations().Any())
			{
				InitDatabase(services);
			}
		}

		public static void InitDatabase(IServiceCollection services)
		{
			using var scope = services.BuildServiceProvider().CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<WriteDbContext>();
			try
			{
				if (!context.Pais.Any())
				{
					var jsonData = File.ReadAllText("PaisesCiudades.json");
					var paisesCiudades = JsonConvert.DeserializeObject<PaisCiudadesDto>(jsonData);
					List<Pais> paises = new();
					foreach (var paisDto in paisesCiudades!.data)
					{
						Pais pais = new(paisDto.country, paisDto.iso2);
						foreach (var ciudadNombre in paisDto.cities)
						{
							pais.AgregarCiudad(ciudadNombre);
						}
						paises.Add(pais);
						context.Ciudad.AddRange(pais.Ciudades);
					}
					context.Pais.AddRange(paises);
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.ToString());
			}
		}

		private static IServiceCollection AddMassTransitWithRabbitMq(IServiceCollection services, IConfiguration configuration)
		{
			var serviceName = configuration.GetValue<string>("ServiceName");
			var rabbitMQSettings = configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();

			services.AddMassTransit(configure =>
			{
				configure.AddConsumer<ReservaFinalizadaConsumer>();
				configure.AddConsumer<ReservaRegistradaConsumer>();
				configure.AddConsumer<CheckOutFinalizadoConsumer>();
				configure.UsingRabbitMq((context, configurator) =>
				{
					bool IsRunningInContainer = bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"), out var inDocker) && inDocker;
					var host = IsRunningInContainer ? "rabbitmq" : "localhost";
					configurator.Host(host);
					configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceName, false));
					configurator.UseMessageRetry(retryConfigurator =>
					{
						retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
					});
				});
			});

			return services;
		}

		public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
			{
				var configSettings = configuration.GetSection(nameof(ConfigurationSetting)).Get<ConfigurationSetting>();
				if (configSettings != null)
				{
					var address = configSettings.ConsulAddresss;
					consulConfig.Address = new Uri(address);
				}
			}));
			return services;
		}

		public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
		{
			var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
			var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtensions");
			var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();

			var configSettings = configuration.GetSection(nameof(ConfigurationSetting)).Get<ConfigurationSetting>();
			var serviceName = configSettings!.ServiceName;
			var serviceHost = configSettings.ServiceHost;
			var servicePort = configSettings.ServicePort;
			var registration = new AgentServiceRegistration()
			{
				ID = serviceName, //{uri.Port}",
								  // servie name  
				Name = serviceName,
				Address = serviceHost, //$"{uri.Host}",
				Port = servicePort  // uri.Port
			};

			logger.LogInformation("Registering with Consul");
			consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
			consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

			lifetime.ApplicationStopping.Register(() =>
			{
				logger.LogInformation("Unregistering from Consul");
			});

			return app;
		}
	}
}