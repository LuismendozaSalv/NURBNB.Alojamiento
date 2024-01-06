using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;

namespace NURBNB.Alojamiento.Infrastructure.EF.Config
{
	internal class PaisConfig : IEntityTypeConfiguration<Pais>
	{
		public void Configure(EntityTypeBuilder<Pais> builder)
		{
			builder.ToTable("pais");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName("paisId");

			builder.Property(x => x.Name)
				.HasColumnName("nombre");

			builder.Property(x => x.CountryCode)
				.HasColumnName("paisCode");

			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
			builder.Ignore(x => x.Ciudades);
		}
	}
}
