using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("coordenada")]
	public class CoordenadaReadModel
	{
		[Required]
		[Column("direccionId")]
		public Guid DireccionId { get; set; }

		[Column("latitud")]
		[Required]
		public double Latitud { get; set; }

		[Column("longitud")]
		[Required]
		public double Longitud { get; set; }
	}
}
