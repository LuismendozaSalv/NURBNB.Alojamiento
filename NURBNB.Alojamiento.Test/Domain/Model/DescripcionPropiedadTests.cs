using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class DescripcionPropiedadTests
	{
		[Fact]
		public void Constructor_ValoresValidos_CreaInstancia()
		{
			// Arrange
			string value = "Descripción de la propiedad";

			// Act
			DescripcionPropiedad descripcion = new DescripcionPropiedad(value);

			// Assert
			Assert.NotNull(descripcion);
			Assert.Equal(value, descripcion.Value);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void Constructor_ValorVacioONulo_ThrowsArgumentException(string value)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new DescripcionPropiedad(value));
		}

		[Fact]
		public void Constructor_ValidarLargoCadena_ThrowsArgumentException()
		{
			// Arrange
			string value = new string('A', 251); // Crear una cadena de más de 250 caracteres

			// Act & Assert
			Assert.Throws<ArgumentException>(() => new DescripcionPropiedad(value));
		}

		[Fact]
		public void OperadorImplicitoAString_ConvertsToString()
		{
			// Arrange
			string value = "Descripción de la propiedad";
			DescripcionPropiedad descripcion = new DescripcionPropiedad(value);

			// Act
			string convertedValue = descripcion;

			// Assert
			Assert.Equal(value, convertedValue);
		}

		[Fact]
		public void OperadorImplicitDesdeString_ConvertsFromString()
		{
			// Arrange
			string value = "Descripción de la propiedad";

			// Act
			DescripcionPropiedad descripcion = value;

			// Assert
			Assert.NotNull(descripcion);
			Assert.Equal(value, descripcion.Value);
		}
	}
}
