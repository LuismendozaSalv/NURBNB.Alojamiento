using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Factories
{
	public class ReservaFactory : IReservaFactory
	{
		public Reserva Crear(Guid reservaId, DateTime fechaEntrada, DateTime fechaSalida, EstadoReserva estado)
		{
			return new Reserva(reservaId, fechaEntrada, fechaSalida, estado);
		}
	}
}
