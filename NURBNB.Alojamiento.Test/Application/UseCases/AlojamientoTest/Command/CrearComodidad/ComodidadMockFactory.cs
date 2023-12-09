using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.CrearComodidad
{
	internal class ComodidadMockFactory
	{
		public static Comodidad ObtenerComodidad()
		{
			return new ComodidadFactory().Crear("Televisión por Cable", "Ofrecer una variedad de canales para el entretenimiento de los huéspedes");
		}
		public static List<Comodidad> ObtenerComodidades()
		{
			return new List<Comodidad>() {
				new ComodidadFactory().Crear("Conexión a Internet Wi-Fi", "Acceso a Internet de alta velocidad en las áreas públicas y habitaciones"),
				new ComodidadFactory().Crear("Televisión por Cable", "Ofrecer una variedad de canales para el entretenimiento de los huéspedes")
			};
		}
	}
}
