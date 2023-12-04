using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Factories
{
	public interface IReservaFactory
	{
		public Reserva Crear(Guid ReservaId, DateTime FechaEntrada, DateTime FechaSalida, EstadoReserva Estado);
	}
}
