using NURBNB.Alojamiento.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.Dto
{
	public class PaisDtoTests
	{
		[Fact]
		public void PaisDto_Initialization_Valid()
		{
			// Arrange
			Guid id = Guid.NewGuid();
			string nombre = "País Ejemplo";
			string codigoPais = "PE";

			// Act
			var paisDto = new PaisDto
			{
				Id = id,
				Nombre = nombre,
				CodigoPais = codigoPais
			};

			// Assert
			Assert.Equal(id, paisDto.Id);
			Assert.Equal(nombre, paisDto.Nombre);
			Assert.Equal(codigoPais, paisDto.CodigoPais);
		}
	}
}
