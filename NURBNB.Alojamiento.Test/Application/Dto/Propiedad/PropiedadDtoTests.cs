using NURBNB.Alojamiento.Application.Dto.Propiedad;
using NURBNB.Alojamiento.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.Dto.Propiedad
{
	public class PropiedadDtoTests
	{
		[Fact]
		public void PropiedadDto_Valida_Inicializacion()
		{
			// Arrange
			string titulo = "Ejemplo de Título";
			string descripcion = "Ejemplo de Descripción";
			decimal precio = 100.0m;
			int personas = 4;
			int camas = 2;
			int habitaciones = 3;
			var fotos = new List<FotoDto>
		{
			new FotoDto { Url = "https://example.com/foto1.jpg" },
			new FotoDto { Url = "https://example.com/foto2.jpg" }
		};

			// Act
			var propiedadDto = new PropiedadDto
			{
				Titulo = titulo,
				Descripcion = descripcion,
				Precio = precio,
				Personas = personas,
				Camas = camas,
				Habitaciones = habitaciones,
				Fotos = fotos
			};

			// Assert
			Assert.Equal(titulo, propiedadDto.Titulo);
			Assert.Equal(descripcion, propiedadDto.Descripcion);
			Assert.Equal(precio, propiedadDto.Precio);
			Assert.Equal(personas, propiedadDto.Personas);
			Assert.Equal(camas, propiedadDto.Camas);
			Assert.Equal(habitaciones, propiedadDto.Habitaciones);

			Assert.NotNull(propiedadDto.Fotos);
			Assert.Equal(2, propiedadDto.Fotos.Count);

			// Verificar que las URLs de las fotos coincidan
			Assert.Equal("https://example.com/foto1.jpg", propiedadDto.Fotos[0].Url);
			Assert.Equal("https://example.com/foto2.jpg", propiedadDto.Fotos[1].Url);
		}
	}
}
