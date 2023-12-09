using NURBNB.Alojamiento.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.Dto
{
	public class CiudadDtoTests
	{
		[Fact]
		public void CiudadDto_Valida_Creacion()
		{
			// Arrange
			Guid id = Guid.NewGuid();
			string nombre = "Ciudad Ejemplo";
			Guid paisId = Guid.NewGuid();
			string nombrePais = "Pais Ejemplo";

			// Act
			var ciudadDto = new CiudadDto
			{
				Id = id,
				Nombre = nombre,
				PaisId = paisId,
				NombrePais = nombrePais
			};

			// Assert
			Assert.Equal(id, ciudadDto.Id);
			Assert.Equal(nombre, ciudadDto.Nombre);
			Assert.Equal(paisId, ciudadDto.PaisId);
			Assert.Equal(nombrePais, ciudadDto.NombrePais);
		}
	}
}
