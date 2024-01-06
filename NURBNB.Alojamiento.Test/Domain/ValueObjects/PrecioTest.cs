using NURBNB.Alojamiento.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.ValueObjects
{
	public class PrecioTest
	{
		[Theory]
		[InlineData(10)]
		[InlineData(100.5)]
		[InlineData(999.99)]
		public void Constructor_ValidarValor_CreaInstancia(decimal value)
		{
			// Arrange & Act
			var precio = new Precio(value);

			// Assert
			Assert.Equal(value, precio.Value);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-5)]
		public void Constructor_ValorInvalido_ThrowsArgumentException(decimal value)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Precio(value));
		}

		[Theory]
		[InlineData(10)]
		[InlineData(100.5)]
		[InlineData(999.99)]
		public void OperadorImplicitoADecimal_ConvertirADecimal(decimal value)
		{
			// Arrange
			var precio = new Precio(value);

			// Act
			decimal convertedValue = precio;

			// Assert
			Assert.Equal(value, convertedValue);
		}

		[Theory]
		[InlineData(10)]
		[InlineData(100.5)]
		[InlineData(999.99)]
		public void OperadorImplicitoDesdeDecimal_ConvertirDesdeDecimal(decimal value)
		{
			// Act
			Precio precio = value;

			// Assert
			Assert.Equal(value, precio.Value);
		}
	}
}
