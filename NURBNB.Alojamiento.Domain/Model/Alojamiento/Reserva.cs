using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
	public class Reserva : Entity
	{
		public DateTime FechaEntrada { get; private set; }
		public DateTime FechaSalida { get; private set; }
		public EstadoReserva EstadoReserva { get; private set; }
		internal Reserva()
		{

		}

		public Reserva(Guid reservaId, DateTime fechaEntrada, DateTime fechaSalida, EstadoReserva estado)
		{
			Id = reservaId;
			FechaEntrada = fechaEntrada;
			FechaSalida = fechaSalida;
			EstadoReserva = estado;
		}

		public void Editar(EstadoReserva estado)
		{
			EstadoReserva = estado;
		}
	}
}
