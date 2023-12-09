using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.CrearPropiedad
{
	internal class PropiedadMockFactory
	{
		protected PropiedadMockFactory() { }
		public static Propiedad GetPropiedadApartamento()
		{
			string titulo = "Propiedad 1";
			string descripcion = "Propiedad 1";
			decimal precio = 200.0M;
			int personas = 10;
			int camas = 5;
			int habitaciones = 5;
			var propiedadEsperada = new PropiedadFactory().CreatePropiedadApartamento(titulo, descripcion, precio, personas, camas, habitaciones, Guid.NewGuid());
			return propiedadEsperada;
		}

		public static Propiedad GetPropiedadCasa()
		{
			string titulo = "Propiedad Casa";
			string descripcion = "Propiedad Casa";
			decimal precio = 200.0M;
			int personas = 10;
			int camas = 10;
			int habitaciones = 5;
			var propiedadEsperada = new PropiedadFactory().CreatePropiedadCasa(titulo, descripcion, precio, personas, camas, habitaciones, Guid.NewGuid());
			return propiedadEsperada;
		}

		public static Propiedad GetPropiedadHabitacion()
		{
			string titulo = "Propiedad Habitacion";
			string descripcion = "Propiedad Habitacion";
			decimal precio = 200.0M;
			int personas = 10;
			int camas = 5;
			int habitaciones = 1;
			var propiedadEsperada = new PropiedadFactory().CreatePropiedadHabitacion(titulo, descripcion, precio, personas, camas, habitaciones, Guid.NewGuid());
			return propiedadEsperada;
		}
	}
}
