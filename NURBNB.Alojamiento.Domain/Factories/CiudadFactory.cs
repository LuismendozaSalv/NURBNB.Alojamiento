using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Factories
{
	public class CiudadFactory : ICiudadFactory
	{
		private readonly IPaisRepository _paisRepository;

		public CiudadFactory(IPaisRepository paisRepository)
		{
			_paisRepository = paisRepository;
		}
		public async Task<Ciudad> Crear(string nombre, Guid PaisId)
		{
			var pais = await _paisRepository.FindByIdAsync(PaisId);
			return new Ciudad(nombre, pais);
		}
	}
}
