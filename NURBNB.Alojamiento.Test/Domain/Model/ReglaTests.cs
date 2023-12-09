using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class ReglaTests
	{
		[Fact]
		public void Constructor_ValorValido_SetValorCorrecto()
		{
			// Arrange
			string value = "Ejemplo de regla";

			// Act
			var regla = new Regla(value);

			// Assert
			Assert.Equal(value, regla.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void Constructor_ValorNuloOVacio_ThrowException(string valorInvalido)
		{
			// Act & Assert
			Assert.Throws<BussinessRuleValidationException>(() => new Regla(valorInvalido));
		}

		[Fact]
		public void ConversionImplicita_AString_RetornaValorCorrecto()
		{
			// Arrange
			string value = "Ejemplo de regla";
			var regla = new Regla(value);

			// Act
			string result = regla;

			// Assert
			Assert.Equal(value, result);
		}

		[Fact]
		public void ConversionImplicita_DesdeString_CreaInstanciaConValorCorrecto()
		{
			// Arrange
			string value = "Ejemplo de regla";

			// Act
			Regla regla = value;

			// Assert
			Assert.Equal(value, regla.Value);
		}
	}
}
