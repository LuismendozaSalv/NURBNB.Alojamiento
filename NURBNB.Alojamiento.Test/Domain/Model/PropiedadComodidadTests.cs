using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class PropiedadComodidadTests
	{
		[Fact]
		public void Constructor_ComodidadIdValido()
		{
			// Arrange
			Guid comodidadId = Guid.NewGuid();

			// Act
			var propiedadComodidad = new PropiedadComodidad(comodidadId);

			// Assert
			Assert.Equal(comodidadId, propiedadComodidad.ComodidadId);
		}

		[Fact]
		public void Constructor_IdUnico()
		{
			// Act
			var propiedadComodidad1 = new PropiedadComodidad(Guid.NewGuid());
			var propiedadComodidad2 = new PropiedadComodidad(Guid.NewGuid());

			// Assert
			Assert.NotEqual(propiedadComodidad1.Id, propiedadComodidad2.Id);
		}
	}
}
