using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Factories
{
	public class PaisFactoryTests
	{
		[Fact]
		public void Crear_PaisInstanceConValoresCorrectos()
		{
			// Arrange
			string nombre = "España";
			string codigoPais = "ES";

			PaisFactory factory = new PaisFactory();

			// Act
			Pais pais = factory.Crear(nombre, codigoPais);

			// Assert
			Assert.NotNull(pais);
			Assert.Equal(nombre, pais.Name);
			Assert.Equal(codigoPais, pais.CountryCode);
		}

		[Theory]
		[InlineData("", "ES")]
		[InlineData("España", "")]
		[InlineData("", "")]
		public void Crear_NombreOCodigoVacio_ThrowsArgumentException(string nombre, string codigoPais)
		{
			// Arrange
			PaisFactory factory = new PaisFactory();

			// Act & Assert
			Assert.Throws<ArgumentException>(() => factory.Crear(nombre, codigoPais));
		}
	}
}
