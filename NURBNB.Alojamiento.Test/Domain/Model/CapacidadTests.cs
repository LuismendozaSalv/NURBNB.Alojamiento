using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class CapacidadTests
	{
		[Fact]
		public void Constructor_ValoresValidos_CrearInstancia()
		{
			// Arrange
			int people = 4;
			int beds = 2;
			int rooms = 2;

			// Act
			Capacidad capacidad = new Capacidad(people, beds, rooms);

			// Assert
			Assert.NotNull(capacidad);
			Assert.Equal(people, capacidad.People);
			Assert.Equal(beds, capacidad.Beds);
			Assert.Equal(rooms, capacidad.Rooms);
		}

		[Theory]
		[InlineData(0, 2, 2)]
		[InlineData(4, 0, 2)]
		[InlineData(4, 2, 0)]
		[InlineData(-1, 2, 2)]
		[InlineData(4, -1, 2)]
		[InlineData(4, 2, -1)]
		public void Constructor_ValoresInvalidos_ThrowsArgumentException(int people, int beds, int rooms)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Capacidad(people, beds, rooms));
		}
	}
}
