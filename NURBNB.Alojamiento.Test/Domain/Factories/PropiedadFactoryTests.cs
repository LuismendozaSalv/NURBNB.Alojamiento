using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Factories
{
	public class PropiedadFactoryTests
	{
		[Fact]
		public void CreatePropiedadApartamento_ReturnsCorrectInstance()
		{
			// Arrange
			string titulo = "Apartamento de lujo";
			string descripcion = "Un hermoso apartamento en el centro de la ciudad.";
			decimal precio = 200.00m;
			int personas = 4;
			int camas = 2;
			int habitaciones = 2;
			var usuarioId = Guid.NewGuid();

			PropiedadFactory factory = new();

			// Act
			Propiedad propiedad = factory.CreatePropiedadApartamento(titulo, descripcion, precio, personas, camas, habitaciones, usuarioId);

			// Assert
			Assert.NotNull(propiedad);
			Assert.Equal(titulo, propiedad.Titulo);
			Assert.Equal(descripcion, propiedad.Descripcion);
			Assert.Equal(TipoPropiedad.Apartamento, propiedad.TipoPropiedad);
			Assert.Equal(precio, (decimal)propiedad.Precio);
			Assert.NotNull(propiedad.Capacidad);
			Assert.Equal(personas, propiedad.Capacidad.People);
			Assert.Equal(camas, propiedad.Capacidad.Beds);
			Assert.Equal(habitaciones, propiedad.Capacidad.Rooms);
		}

		[Fact]
		public void CreatePropiedadCasa_ReturnsCorrectInstance()
		{
			// Arrange
			string titulo = "Casa en la playa";
			string descripcion = "Una hermosa casa frente al mar.";
			decimal precio = 400.00m;
			int personas = 8;
			int camas = 4;
			int habitaciones = 3;
			var usuarioId = Guid.NewGuid();
			PropiedadFactory factory = new();

			// Act
			Propiedad propiedad = factory.CreatePropiedadCasa(titulo, descripcion, precio, personas, camas, habitaciones, usuarioId);

			// Assert
			Assert.NotNull(propiedad);
			Assert.Equal(titulo, propiedad.Titulo);
			Assert.Equal(descripcion, propiedad.Descripcion);
			Assert.Equal(TipoPropiedad.Casa, propiedad.TipoPropiedad);
			Assert.Equal(precio, (decimal)propiedad.Precio);
			Assert.NotNull(propiedad.Capacidad);
			Assert.Equal(personas, propiedad.Capacidad.People);
			Assert.Equal(camas, propiedad.Capacidad.Beds);
			Assert.Equal(habitaciones, propiedad.Capacidad.Rooms);
		}

		[Fact]
		public void CreatePropiedadHabitacion_ReturnsCorrectInstance()
		{
			// Arrange
			string titulo = "Habitación acogedora";
			string descripcion = "Una habitación individual con todas las comodidades.";
			decimal precio = 50.00m;
			int personas = 1;
			int camas = 1;
			int habitaciones = 1;
			var usuarioId = Guid.NewGuid();
			PropiedadFactory factory = new();

			// Act
			Propiedad propiedad = factory.CreatePropiedadHabitacion(titulo, descripcion, precio, personas, camas, habitaciones, usuarioId);

			// Assert
			Assert.NotNull(propiedad);
			Assert.Equal(titulo, propiedad.Titulo);
			Assert.Equal(descripcion, propiedad.Descripcion);
			Assert.Equal(TipoPropiedad.Habitacion, propiedad.TipoPropiedad);
			Assert.Equal(precio, (decimal)propiedad.Precio);
			Assert.NotNull(propiedad.Capacidad);
			Assert.Equal(personas, propiedad.Capacidad.People);
			Assert.Equal(camas, propiedad.Capacidad.Beds);
			Assert.Equal(habitaciones, propiedad.Capacidad.Rooms);
		}
	}
}
