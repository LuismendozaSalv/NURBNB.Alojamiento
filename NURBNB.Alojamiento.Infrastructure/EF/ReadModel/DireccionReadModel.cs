using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("direccion")]
	public class DireccionReadModel
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }

		[Required]
		[Column("propiedadId")]
		public Guid PropiedadId { get; set; }
		public PropiedadReadModel Propiedad { get; set; }

		[Column("calle")]
		[StringLength(150)]
		[Required]
		public string Calle { get; set; }

		[Column("avenida")]
		[StringLength(150)]
		[Required]
		public string Avenida { get; set; }

		[Column("referencia")]
		[StringLength(150)]
		[Required]
		public string Referencia { get; set; }

		[Column("latitud")]
		[Required]
		public double Latitud { get; set; }

		[Column("longitud")]
		[Required]
		public double Longitud { get; set; }

		[Required]
		[Column("ciudadId")]
		public Guid CiudadId { get; set; }
		public CiudadReadModel Ciudad { get; set; }
	}
}
