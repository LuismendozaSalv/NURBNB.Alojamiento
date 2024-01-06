using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Domain.Factories
{
	public class ComodidadFactoryTests
	{
		[Fact]
		public void Crear_ComodidadConValoresCorrectos()
		{
			// Arrange
			string nombre = "Wifi";
			string descripcion = "Acceso a Internet inalámbrico";

			ComodidadFactory factory = new ComodidadFactory();

			// Act
			Comodidad comodidad = factory.Crear(nombre, descripcion);

			// Assert
			Assert.NotNull(comodidad);
			Assert.Equal(nombre, comodidad.Nombre);
			Assert.Equal(descripcion, comodidad.Descripcion);
		}

		[Theory]
		[InlineData("", "Acceso a Internet inalámbrico")]
		[InlineData("Wifi", "")]
		public void CrearComodidad_NombreODescripcionVacio_ThrowsArgumentException(string nombre, string descripcion)
		{
			// Arrange
			ComodidadFactory factory = new ComodidadFactory();

			// Act & Assert
			Assert.Throws<BussinessRuleValidationException>(() => factory.Crear(nombre, descripcion));
		}
	}
}
