using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("reserva")]
	public class ReservaReadModel
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }

		[Required]
		[Column("propiedadId")]
		public Guid PropiedadId { get; set; }

		[Column("fechaEntrada")]
		[Required]
		public DateTime FechaEntrada { get; set; }

		[Column("fechaSalida")]
		[Required]
		public DateTime FechaSalida { get; set; }

		[Required]
		[Column("estadoReserva")]
		[MaxLength(25)]
		public string EstadoReserva { get; set; }
	}
}
