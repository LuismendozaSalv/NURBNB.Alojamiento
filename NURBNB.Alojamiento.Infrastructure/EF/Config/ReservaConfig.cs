using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.Config
{
    public class ReservaConfig : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("reserva");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("reservaId");

            builder.Property(x => x.FechaEntrada)
                .HasColumnName("fechaEntrada");

            builder.Property(x => x.FechaSalida)
                .HasColumnName("fechaSalida");

            var tipoConverter = new ValueConverter<EstadoReserva, string>(
                tipoEnumValue => tipoEnumValue.ToString(),
                tipo => (EstadoReserva)Enum.Parse(typeof(EstadoReserva), tipo)
            );

            builder.Property(x => x.EstadoReserva)
                 .HasConversion(tipoConverter)
                 .HasColumnName("estadoReserva")
                 .HasMaxLength(20)
                 .IsRequired();

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
