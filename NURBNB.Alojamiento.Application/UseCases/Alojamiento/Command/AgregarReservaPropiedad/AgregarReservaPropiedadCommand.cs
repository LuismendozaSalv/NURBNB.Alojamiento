using MediatR;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarReservaPropiedad
{
	public class AgregarReservaPropiedadCommand : IRequest<Guid>
	{
		public Guid PropiedadId { get; set; }
		public Guid ReservaId { get; set; }
		public DateTime FechaEntrada { get; set; }
		public DateTime FechaSalida { get; set; }
		public EstadoReserva Estado { get; set; }
	}
}
