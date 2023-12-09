using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.Config
{
	public class ComodidadConfig : IEntityTypeConfiguration<Comodidad>
	{
		public void Configure(EntityTypeBuilder<Comodidad> builder)
		{
			builder.ToTable("comodidad");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("comodidadId");

			builder.Property(x => x.Nombre)
				.HasColumnName("nombre");

			builder.Property(x => x.Descripcion)
				.HasColumnName("descripcion");

			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
		}
	}
}
