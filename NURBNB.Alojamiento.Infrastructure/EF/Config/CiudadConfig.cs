using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.Config
{
	internal class CiudadConfig : IEntityTypeConfiguration<Ciudad>
	{
		public void Configure(EntityTypeBuilder<Ciudad> builder)
		{
			builder.ToTable("ciudad");
			builder.HasKey(x => x.Id);


			builder.Property(x => x.Id)
				.HasColumnName("ciudadId");

			builder.Property(x => x.Name)
				.HasColumnName("nombre");
			builder.HasOne(x => x.Country).WithMany(x => x.Ciudades).HasForeignKey("paisId").IsRequired();

			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
		}
	}
}
