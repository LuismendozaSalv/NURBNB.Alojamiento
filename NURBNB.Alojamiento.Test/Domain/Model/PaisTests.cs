using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class PaisTests
	{
		[Fact]
		public void Constructor_ValidNameAndCountryCode_ShouldSetProperties()
		{
			// Arrange
			string name = "México";
			string countryCode = "MX";

			// Act
			var pais = new Pais(name, countryCode);

			// Assert
			Assert.Equal(name, pais.Name);
			Assert.Equal(countryCode, pais.CountryCode);
		}

		[Theory]
		[InlineData(null, "MX")]
		[InlineData("", "MX")]
		[InlineData("México", null)]
		[InlineData("México", "")]
		public void Constructor_InvalidArguments_ShouldThrowException(string name, string countryCode)
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Pais(name, countryCode));
		}

		[Fact]
		public void AgregarCiudad_ShouldAddCiudadToCiudadesCollection()
		{
			// Arrange
			var pais = new Pais("México", "MX");
			string ciudadName = "Ciudad de México";

			// Act
			pais.AgregarCiudad(ciudadName);

			// Assert
			Assert.Single(pais.Ciudades);
			Assert.Equal(ciudadName, pais.Ciudades.First().Name);
		}
	}
}
