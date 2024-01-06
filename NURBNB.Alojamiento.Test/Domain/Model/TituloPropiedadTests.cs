using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class TituloPropiedadTests
	{
		[Fact]
		public void Constructor_ValorValido()
		{
			// Arrange
			string valor = "Ejemplo de título";

			// Act
			var tituloPropiedad = new TituloPropiedad(valor);

			// Assert
			Assert.Equal(valor, tituloPropiedad.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_ValorVacioONulo_ThrowArgumentException(string valorInvalido)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new TituloPropiedad(valorInvalido));
		}

		[Fact]
		public void Constructor_ValueDemasiadoLargo_ThrowArgumentException()
		{
			// Arrange
			string longValue = new string('A', 101);

			// Act & Assert
			Assert.Throws<ArgumentException>(() => new TituloPropiedad(longValue));
		}

		[Fact]
		public void ConversionImplicita_AString_RetornValorCorrecto()
		{
			// Arrange
			string value = "Ejemplo de título";
			var tituloPropiedad = new TituloPropiedad(value);

			// Act
			string result = tituloPropiedad;

			// Assert
			Assert.Equal(value, result);
		}

		[Fact]
		public void ConversionImplicita_DesdeString_CreaInstanciaConValorCorrecto()
		{
			// Arrange
			string value = "Ejemplo de título";

			// Act
			TituloPropiedad tituloPropiedad = value;

			// Assert
			Assert.Equal(value, tituloPropiedad.Value);
		}
	}
}
