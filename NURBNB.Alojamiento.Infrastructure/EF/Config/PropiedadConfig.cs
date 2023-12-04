using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.Config
{
	internal class PropiedadConfig : IEntityTypeConfiguration<Propiedad>,
		IEntityTypeConfiguration<Direccion>, IEntityTypeConfiguration<PropiedadComodidad>
	{
		public void Configure(EntityTypeBuilder<Propiedad> builder)
		{
			builder.ToTable("propiedad");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
			.HasColumnName("propiedadId");

			builder.Property(x => x.UsuarioId)
			.HasColumnName("usuarioId");

			var tituloConverter = new ValueConverter<TituloPropiedad, string>(
				tituloValue => tituloValue.Value,
				titulo => new TituloPropiedad(titulo)
			);

			builder.Property(x => x.Titulo)
				.HasConversion(tituloConverter)
				.HasColumnName("titulo");

			var descripcionConverter = new ValueConverter<DescripcionPropiedad, string>(
				descripcionValue => descripcionValue.Value,
				descripcion => new DescripcionPropiedad(descripcion)
			);

			builder.Property(x => x.Descripcion)
				.HasConversion(descripcionConverter)
				.HasColumnName("descripcion");

			var precioConverter = new ValueConverter<Precio, decimal>(
				precio => precio.Value,
				precio => new Precio(precio)
			);

			builder.Property(x => x.Precio)
				.HasConversion(precioConverter)
				.HasColumnName("precio");

			var tipoConverter = new ValueConverter<TipoPropiedad, string>(
				tipoEnumValue => tipoEnumValue.ToString(),
				tipo => (TipoPropiedad)Enum.Parse(typeof(TipoPropiedad), tipo)
			);

			builder.Property(x => x.TipoPropiedad)
				 .HasConversion(tipoConverter)
				 .HasColumnName("tipoPropiedad")
				 .HasMaxLength(20)
				 .IsRequired();

			builder.OwnsOne(
				e => e.Capacidad,
				capacidad =>
				{
					capacidad.Property(c => c.People).HasColumnName("personas");
					capacidad.Property(c => c.Beds).HasColumnName("camas");
					capacidad.Property(c => c.Rooms).HasColumnName("habitaciones");
				}
			);

			builder.OwnsOne(e => e.Direccion);

			builder.OwnsMany(e => e.Fotos);
			builder.OwnsMany(e => e.Reglas);
			var estadoConverter = new ValueConverter<EstadoReserva, string>(
				tipoEnumValue => tipoEnumValue.ToString(),
				tipo => (EstadoReserva)Enum.Parse(typeof(EstadoReserva), tipo)
			);
			builder.OwnsMany(e => e.Reservas, reserva =>
			{
				reserva.Property(r => r.EstadoReserva)
				 .HasConversion(estadoConverter)
				 .HasColumnName("estadoReserva")
				 .HasMaxLength(20)
				 .IsRequired();
			});
			builder.HasMany(typeof(PropiedadComodidad), "_comodidades");
			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
			builder.Ignore(x => x.Comodidades);
		}

		public void Configure(EntityTypeBuilder<Direccion> builder)
		{
			builder.ToTable("direccion");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
			.HasColumnName("Id");

			builder.Property(x => x.Calle)
			.HasColumnName("calle");

			builder.Property(x => x.Avenida)
			.HasColumnName("avenida");

			builder.Property(x => x.Referencia)
			.HasColumnName("referencia");

			builder.Property(x => x.Latitud)
			.HasColumnName("latitud");

			builder.Property(x => x.Longitud)
			.HasColumnName("longitud");

			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
		}

		public void Configure(EntityTypeBuilder<PropiedadComodidad> builder)
		{
			builder.ToTable("propiedadComodidad");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("Id");

			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
		}

	}
}
