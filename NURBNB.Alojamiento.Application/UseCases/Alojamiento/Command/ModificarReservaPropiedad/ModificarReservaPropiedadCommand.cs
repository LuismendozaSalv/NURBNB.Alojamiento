using MediatR;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.ModificarReservaPropiedad
{
	public class ModificarReservaPropiedadCommand : IRequest<Guid>
	{
		public Guid ReservaId { get; set; }
		public EstadoReserva Estado { get; set; }
	}
}
