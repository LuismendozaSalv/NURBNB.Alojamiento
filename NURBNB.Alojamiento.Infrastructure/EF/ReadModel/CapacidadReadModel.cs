using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	public class CapacidadReadModel
	{
		[Required]
		[Column("personas")]
		public int Personas { get; set; }

		[Required]
		[Column("camas")]
		public int Camas { get; set; }

		[Required]
		[Column("habitaciones")]
		public int Habitaciones { get; set; }
	}
}
