using Moq;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Factories
{
	public class CiudadFactoryTests
	{
		[Fact]
		public async Task Crear_ReturnsCiudadInstanceWithCorrectValues()
		{
			// Arrange
			string nombre = "Ciudad Ejemplo";
			Guid paisId = Guid.NewGuid();

			// Crear un mock del IPaisRepository
			var mockPaisRepository = new Mock<IPaisRepository>();

			// Configurar el comportamiento del mock para que devuelva un objeto Pais ficticio
			var paisFicticio = new Pais("País Ejemplo", "PE");
			mockPaisRepository.Setup(repo => repo.FindByIdAsync(It.IsAny<Guid>())).ReturnsAsync(paisFicticio);

			CiudadFactory factory = new CiudadFactory(mockPaisRepository.Object);

			// Act
			Ciudad ciudad = await factory.Crear(nombre, paisId);

			// Assert
			Assert.NotNull(ciudad);
			Assert.Equal(nombre, ciudad.Name);
			Assert.Equal(paisFicticio, ciudad.Country);
		}
	}
}
