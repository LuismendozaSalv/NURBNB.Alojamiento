using NURBNB.Alojamiento.Application.UseCases.Comodidad.AgregarComodidad.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.ComodidadTest.Command
{
	public class CrearComodidadCommandTests
	{
		[Fact]
		public void CrearComodidadCommand_Valida_Inicializacion()
		{
			// Arrange
			string nombre = "Comodidad Ejemplo";
			string descripcion = "Descripción de la comodidad";

			// Act
			var crearComodidadCommand = new CrearComodidadCommand
			{
				Nombre = nombre,
				Descripcion = descripcion
			};

			// Assert
			Assert.Equal(nombre, crearComodidadCommand.Nombre);
			Assert.Equal(descripcion, crearComodidadCommand.Descripcion);
		}
	}
}
