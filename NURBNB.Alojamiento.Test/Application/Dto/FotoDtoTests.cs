using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.Dto
{
	public class FotoDtoTests
	{
		[Fact]
		public void FotoDto_Valida_Inicializacion()
		{
			// Arrange
			string url = "https://example.com/image.jpg";

			// Act
			var fotoDto = new FotoDto
			{
				Url = url
			};

			// Assert
			Assert.Equal(url, fotoDto.Url);
		}
	}
}
