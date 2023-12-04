using NURBNB.Alojamiento.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.Dto
{
	public class ReglaDtoTests
	{
		[Fact]
		public void ReglaDto_Valida_InicializaCion()
		{
			// Arrange
			string value = "Ejemplo de valor";

			// Act
			var reglaDto = new ReglaDto
			{
				Value = value
			};

			// Assert
			Assert.Equal(value, reglaDto.Value);
		}
	}
}
