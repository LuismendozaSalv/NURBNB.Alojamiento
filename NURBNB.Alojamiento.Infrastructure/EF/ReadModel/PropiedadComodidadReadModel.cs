using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("propiedadComodidad")]
	public class PropiedadComodidadReadModel
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }

		[Required]
		[Column("comodidadId")]
		public Guid ComodidadId { get; set; }
		public ComodidadReadModel Comodidad { get; set; }

		[Required]
		[Column("propiedadId")]
		public Guid PropiedadId { get; set; }
		public PropiedadReadModel Propiedad { get; set; }
	}
}
