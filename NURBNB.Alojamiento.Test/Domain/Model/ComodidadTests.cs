using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Model
{
	public class ComodidadTests
	{
		[Fact]
		public void Constructor_ValidValues_CreatesInstance()
		{
			// Arrange
			string nombre = "Wifi";
			string descripcion = "Acceso a Internet inalámbrico";

			// Act
			Comodidad comodidad = new(nombre, descripcion);

			// Assert
			Assert.NotNull(comodidad);
			Assert.Equal(nombre, comodidad.Nombre);
			Assert.Equal(descripcion, comodidad.Descripcion);
		}

		[Fact]
		public void Constructor_EmptyNombre_ThrowsArgumentException()
		{
			// Arrange
			string nombre = "";
			string descripcion = "Acceso a Internet inalámbrico";

			// Act & Assert
			Assert.Throws<BussinessRuleValidationException>(() => new Comodidad(nombre, descripcion));
		}

		[Fact]
		public void Constructor_NullNombre_ThrowsArgumentException()
		{
			// Arrange
			string? nombre = null;
			string descripcion = "Acceso a Internet inalámbrico";

			// Act & Assert
			Assert.Throws<BussinessRuleValidationException>(() => new Comodidad(nombre, descripcion));
		}

		[Fact]
		public void Constructor_EmptyDescripcion_ThrowsArgumentException()
		{
			// Arrange
			string nombre = "Wifi";
			string descripcion = "";

			// Act & Assert
			Assert.Throws<BussinessRuleValidationException>(() => new Comodidad(nombre, descripcion));
		}

		[Fact]
		public void Constructor_NullDescripcion_ThrowsArgumentException()
		{
			// Arrange
			string nombre = "Wifi";
			string? descripcion = null;

			// Act & Assert
			Assert.Throws<BussinessRuleValidationException>(() => new Comodidad(nombre, descripcion));
		}
	}

}
