using Moq;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class DireccionTests
	{
		Mock<IPaisRepository> _paisRepository;

		public DireccionTests()
		{
			_paisRepository = new Mock<IPaisRepository>();
		}
		[Fact]
		public void Constructor_ValoresValidos_CreaInstancia()
		{
			// Arrange
			Guid propiedadId = Guid.NewGuid();
			string calle = "Calle Principal";
			string avenida = "Avenida Secundaria";
			string referencia = "Referencia Importante";
			double latitud = 10.123456;
			double longitud = -75.987654;
			PaisFactory paisFactory = new PaisFactory();
			var paisEjemplo = paisFactory.Crear("País Ejemplo", "PE");
			CiudadFactory ciudadFactory = new CiudadFactory(_paisRepository.Object);
			Ciudad ciudad = ciudadFactory.Crear("Ciudad Ejemplo", paisEjemplo.Id).Result;

			// Act
			Direccion direccion = new Direccion(propiedadId, calle, avenida, referencia, latitud, longitud, ciudad);

			// Assert
			Assert.NotNull(direccion);
			Assert.Equal(propiedadId, direccion.PropiedadId);
			Assert.Equal(calle, direccion.Calle);
			Assert.Equal(avenida, direccion.Avenida);
			Assert.Equal(referencia, direccion.Referencia);
			Assert.Equal(latitud, direccion.Latitud);
			Assert.Equal(longitud, direccion.Longitud);
			Assert.Equal(ciudad, direccion.Ciudad);
		}

		[Theory]
		[InlineData("", "Avenida Secundaria", "Referencia Importante", 10.123456, -75.987654)]
		[InlineData("Calle Principal", "", "Referencia Importante", 10.123456, -75.987654)]
		[InlineData("Calle Principal", "Avenida Secundaria", "", 10.123456, -75.987654)]
		[InlineData("Calle Principal", "Avenida Secundaria", "Referencia Importante", 100.0, -75.987654)]
		[InlineData("Calle Principal", "Avenida Secundaria", "Referencia Importante", 10.123456, -200.0)]
		public void Constructor_ValoresInvalidos_ThrowsArgumentException(string calle, string avenida, string referencia, double latitud, double longitud)
		{
			// Arrange
			Guid propiedadId = Guid.NewGuid();
			PaisFactory paisFactory = new PaisFactory();
			var paisEjemplo = paisFactory.Crear("País Ejemplo", "PE");
			CiudadFactory ciudadFactory = new CiudadFactory(_paisRepository.Object);
			Ciudad ciudad = ciudadFactory.Crear("Ciudad Ejemplo", paisEjemplo.Id).Result;

			// Act & Assert
			Assert.Throws<BussinessRuleValidationException>(() => new Direccion(propiedadId, calle, avenida, referencia, latitud, longitud, ciudad));
		}
	}
}
