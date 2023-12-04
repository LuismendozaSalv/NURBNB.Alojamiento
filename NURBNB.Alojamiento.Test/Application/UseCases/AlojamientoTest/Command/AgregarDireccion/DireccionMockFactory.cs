using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.AgregarDireccion
{
	internal class DireccionMockFactory
	{
		public static Propiedad addDireccion(Propiedad propiedad, Ciudad ciudad)
		{
			propiedad.AgregarDireccion(
				"Calle nueva",
				"Avenida nueva",
				"Porton cafe",
				-17.793288643202846,
				-63.169714912465764,
				ciudad);
			return propiedad;
		}
	}
}
