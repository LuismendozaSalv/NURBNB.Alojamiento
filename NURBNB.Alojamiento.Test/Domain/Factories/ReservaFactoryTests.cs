using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Factories
{
	public class ReservaFactoryTests
	{
		[Fact]
		public void Crear_ReservaInstanceConValoresCorrectos()
		{
			// Arrange
			DateTime fechaEntrada = DateTime.Now;
			DateTime fechaSalida = DateTime.Now;

			ReservaFactory factory = new ReservaFactory();

			// Act
			Reserva reserva = factory.Crear(Guid.NewGuid(), fechaEntrada, fechaSalida, EstadoReserva.Pendiente);

			// Assert
			Assert.NotNull(reserva);
			Assert.Equal(fechaEntrada, reserva.FechaEntrada);
		}
	}
}
