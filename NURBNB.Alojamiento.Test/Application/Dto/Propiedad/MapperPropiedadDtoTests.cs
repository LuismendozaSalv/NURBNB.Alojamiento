using NURBNB.Alojamiento.Application.Dto.Propiedad;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.Dto.Propiedad
{
	public class MapperPropiedadDtoTests
	{
		[Fact]
		public void MapToPropiedadDto_ShouldMapPropertiesCorrectly()
		{
			// Arrange
			// Arrange
			string titulo = "Ejemplo de título";
			string descripcion = "Ejemplo de descripción";
			Alojamiento.Domain.Model.Alojamiento.TipoPropiedad tipoPropiedad = Alojamiento.Domain.Model.Alojamiento.TipoPropiedad.Casa;
			decimal precio = 100000;
			Capacidad capacidad = new(8, 8, 4);

			// Act
			var propiedad = new Alojamiento.Domain.Model.Alojamiento.Propiedad(titulo, descripcion, tipoPropiedad, precio, capacidad, Guid.NewGuid());


			// Act
			var resultado = MapperPropiedadDto.MapToPropiedadDto(propiedad);

			// Assert
			Assert.Equal(propiedad.Id, resultado.Id);
			Assert.Equal(propiedad.Titulo, resultado.Titulo);
			Assert.Equal(propiedad.Descripcion, resultado.Descripcion);
			Assert.Equal(propiedad.Capacidad.Beds, resultado.Camas);
			Assert.Equal(propiedad.Capacidad.People, resultado.Personas);
			Assert.Equal(propiedad.Capacidad.Rooms, resultado.Habitaciones);
			Assert.Equal(propiedad.TipoPropiedad.ToString(), resultado.TipoPropiedad);
			Assert.Equal(propiedad.Fotos.Count(), resultado.Fotos.Count);
		}
	}

}
