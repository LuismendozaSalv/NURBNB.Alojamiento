using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class ReservaTests
	{
		[Fact]
		public void Constructor_ValidValues_CreatesInstance()
		{
			DateTime fechaEntrada = DateTime.Now;
			DateTime fechaSalida = DateTime.Now;

			ReservaFactory factory = new ReservaFactory();

			// Act
			Reserva reserva = new Reserva(Guid.NewGuid(), fechaEntrada, fechaSalida, EstadoReserva.Pendiente);

			// Assert
			Assert.NotNull(reserva);
			Assert.Equal(fechaEntrada, reserva.FechaEntrada);
		}
	}
}
