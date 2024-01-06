using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.CrearPropiedad;
using NURBNB.Alojamiento.Test.Application.UseCases.CiudadTest.Command.CrearCiudad;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class PropiedadTests
	{
		[Fact]
		public void Constructor_ArgumentosValidos_DebeCrearseCorrectamente()
		{
			// Arrange
			string titulo = "Ejemplo de título";
			string descripcion = "Ejemplo de descripción";
			TipoPropiedad tipoPropiedad = TipoPropiedad.Casa;
			decimal precio = 100000;
			Capacidad capacidad = new(8, 8, 4);

			// Act
			var propiedad = new Propiedad(titulo, descripcion, tipoPropiedad, precio, capacidad, Guid.NewGuid());

			// Assert
			Assert.Equal(titulo, propiedad.Titulo);
			Assert.Equal(descripcion, propiedad.Descripcion);
			Assert.Equal(tipoPropiedad, propiedad.TipoPropiedad);
			Assert.Equal(precio, (decimal)propiedad.Precio);
			Assert.Equal(capacidad, propiedad.Capacidad);
		}

		[Theory]
		[InlineData(null, "Ejemplo de descripción", TipoPropiedad.Casa, 100000, 8, 8, 4)]
		[InlineData("Ejemplo de título", "", TipoPropiedad.Casa, 100000, 8, 8, 4)]
		[InlineData("Ejemplo de título", "Ejemplo de descripción", null, 0, 8, 8, 4)]
		[InlineData("Ejemplo de título", "Ejemplo de descripción", TipoPropiedad.Casa, 0, 8, 8, 4)]
		public void Constructor_ArgumentsInvalidos_DebeLanzarException(string titulo, string descripcion, TipoPropiedad tipoPropiedad,
			decimal precio, int personas, int camas, int habitaciones)
		{
			//Arrange
			Capacidad capacidad = new(personas, camas, habitaciones);
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Propiedad(titulo, descripcion, tipoPropiedad, precio, capacidad, Guid.NewGuid()));
		}

		[Fact]
		public void AgregarDireccion_ArgumentosValidos_DebeAgregarDireccion()
		{
			// Arrange
			var propiedad = new Propiedad("Título", "Descripción", TipoPropiedad.Casa, 100000, new Capacidad(4, 4, 4), Guid.NewGuid());
			string calle = "Calle Principal";
			string avenida = "Avenida Principal";
			string referencia = "Referencia";
			double latitud = -17.790760021163553;
			double longitud = -63.14066671428328;
			Ciudad ciudad = CiudadMockFactory.GetCiudad();

			// Act
			propiedad.AgregarDireccion(calle, avenida, referencia, latitud, longitud, ciudad);

			// Assert
			Assert.NotNull(propiedad.Direccion);
			Assert.Equal(calle, propiedad.Direccion.Calle);
			Assert.Equal(avenida, propiedad.Direccion.Avenida);
			Assert.Equal(referencia, propiedad.Direccion.Referencia);
			Assert.Equal(latitud, propiedad.Direccion.Latitud);
			Assert.Equal(longitud, propiedad.Direccion.Longitud);
			Assert.Equal(ciudad, propiedad.Direccion.Ciudad);
		}

		[Theory]
		[InlineData("Calle Principal", "", "Referencia", -17.790760021163553, -63.14066671428328)]
		[InlineData("", "Avenida Principal", "Referencia", -17.790760021163553, -63.14066671428328)]
		[InlineData("Calle Principal", "Avenida Principal", "", -17.790760021163553, -63.14066671428328)]
		[InlineData("Calle Principal", "Avenida Principal", "Referencia", -200.790760021163553, -63.14066671428328)]
		[InlineData("Calle Principal", "Avenida Principal", "Referencia", -17.790760021163553, -263.14066671428328)]
		public void AgregarDireccion_ArgumentosValidos_DebeLanzarException(string calle, string avenida, string referencia,
			double latitud, double longitud)
		{
			//Arrange
			Propiedad propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			Ciudad ciudad = CiudadMockFactory.GetCiudad();
			// Act & Assert
			Assert.Throws<BussinessRuleValidationException>(() => propiedad.AgregarDireccion(calle, avenida, referencia, latitud, longitud, ciudad));
		}

		[Fact]
		public void AgregarComodidad_ComodidadValida_DebeAgregarComodidad()
		{
			// Arrange
			var propiedad = new Propiedad("Título", "Descripción", TipoPropiedad.Casa, 100000, new Capacidad(4, 4, 4), Guid.NewGuid());
			string nombre = "Wifi";
			string descripcion = "Acceso a Internet inalámbrico";

			// Act
			Comodidad comodidad = new(nombre, descripcion);

			// Act
			propiedad.AgregarComodidad(comodidad.Id);

			// Assert
			Assert.Single(propiedad.Comodidades);
			Assert.Equal(comodidad.Id, propiedad.Comodidades.First().ComodidadId);
		}

		[Theory]
		[InlineData("Wifi", "Acceso a Internet inalámbrico")]
		public void AgregarComodidad_ComodidadRepetida_DebeLanzarExcepcion(string nombre, string descripcion)
		{
			//Arrange
			Propiedad propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			var comodidadId = new Comodidad(nombre, descripcion).Id;
			propiedad.AgregarComodidad(comodidadId);
			// Act & Assert
			Assert.Throws<ArgumentException>(() => propiedad.AgregarComodidad(comodidadId));
		}

		[Fact]
		public void AgregarFoto_UrlValida_DebeAgregarFoto()
		{
			// Arrange
			var propiedad = new Propiedad("Título", "Descripción", TipoPropiedad.Casa, 100000, new Capacidad(4, 4, 2), Guid.NewGuid());
			string url = "https://example.com/image.jpg";

			// Act
			propiedad.AgregarFoto(url);

			// Assert
			Assert.Single(propiedad.Fotos);
			Assert.Equal(url, propiedad.Fotos.First().Url);
		}

		[Theory]
		[InlineData("https://example.com/image.jpg")]
		public void AgregarFoto_UrlRepetida_DebeLanzarExcepcion(string url)
		{
			//Arrange
			Propiedad propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			propiedad.AgregarFoto(url);
			// Act & Assert
			Assert.Throws<ArgumentException>(() => propiedad.AgregarFoto(url));
		}

		[Fact]
		public void AgregarRegla_ReglaValida_DebeAgregarRegla()
		{
			// Arrange
			var propiedad = new Propiedad("Título", "Descripción", TipoPropiedad.Casa, 100000, new Capacidad(4, 4, 4), Guid.NewGuid());
			string regla = "Regla de ejemplo";

			// Act
			propiedad.AgregarRegla(regla);

			// Assert
			Assert.Single(propiedad.Reglas);
			Assert.Equal(regla, propiedad.Reglas.First().Value);
		}

		[Theory]
		[InlineData("Regla de ejemplo")]
		public void AgregarRegla_ReglaRepetida_DebeLanzarExcepcion(string regla)
		{
			//Arrange
			Propiedad propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			propiedad.AgregarRegla(regla);
			// Act & Assert
			Assert.Throws<ArgumentException>(() => propiedad.AgregarRegla(regla));
		}


		[Fact]
		public void AgregarReserva_DebeAgregarRegla()
		{
			//Arrange
			DateTime fechaEntrada = DateTime.Now;
			DateTime fechaSalida = DateTime.Now;

			ReservaFactory factory = new ReservaFactory();

			// Act
			Reserva reserva = factory.Crear(Guid.NewGuid(), fechaEntrada, fechaSalida, EstadoReserva.Pendiente);
			Propiedad propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			propiedad.AgregarReserva(reserva);

			// Assert
			Assert.Equal(reserva.Id, propiedad.Reservas.First().Id);
		}

	}
}
