using Moq;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class CiudadTests
	{
		private readonly Mock<IPaisRepository> _paisRepository;
		private readonly PaisFactory _paisFactory;
		public CiudadTests()
		{
			_paisRepository = new Mock<IPaisRepository>();
			_paisFactory = new PaisFactory();
		}
		[Fact]
		public void Constructor_ValoresValidos_CreaInstancia()
		{
			// Arrange
			string name = "Ciudad Ejemplo";
			var paisEjemplo = _paisFactory.Crear("País Ejemplo", "PE");
			_paisRepository.Setup(_paisRepository => _paisRepository.FindByIdAsync(paisEjemplo.Id))
				.ReturnsAsync(paisEjemplo);
			// Act
			Ciudad ciudad = new(name, paisEjemplo);

			// Assert
			Assert.NotNull(ciudad);
			Assert.Equal(name, ciudad.Name);
			Assert.Equal(paisEjemplo, ciudad.Country);
		}

		[Fact]
		public void Constructor_NombreVacio_ThrowsArgumentException()
		{
			// Arrange
			string name = "";

			var paisEjemplo = _paisFactory.Crear("País Ejemplo", "PE");
			_paisRepository.Setup(_paisRepository => _paisRepository.FindByIdAsync(paisEjemplo.Id))
				.ReturnsAsync(paisEjemplo);
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Ciudad(name, paisEjemplo));
		}

		[Fact]
		public void Constructor_NombreNulo_ThrowsArgumentException()
		{
			// Arrange
			string? name = null;
			var paisEjemplo = _paisFactory.Crear("País Ejemplo", "PE");
			_paisRepository.Setup(_paisRepository => _paisRepository.FindByIdAsync(paisEjemplo.Id))
				.ReturnsAsync(paisEjemplo);
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Ciudad(name, paisEjemplo));
		}
	}
}
