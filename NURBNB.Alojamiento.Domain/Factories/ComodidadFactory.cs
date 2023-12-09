using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Factories
{
	public class ComodidadFactory : IComodidadFactory
	{
		public Comodidad Crear(string nombre, string descripcion)
		{
			return new Comodidad(nombre, descripcion);
		}
	}
}
