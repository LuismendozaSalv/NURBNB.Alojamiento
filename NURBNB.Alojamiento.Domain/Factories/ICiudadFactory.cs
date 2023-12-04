using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Factories
{
	public interface ICiudadFactory
	{
		public Task<Ciudad> Crear(string nombre, Guid PaisId);

	}
}
