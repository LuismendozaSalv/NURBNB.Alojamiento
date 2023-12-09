using Moq;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.CiudadTest.Command.CrearCiudad
{
	internal class CiudadMockFactory
	{
		protected CiudadMockFactory() { }
		public static Ciudad GetCiudad()
		{
			Mock<IPaisRepository> _paisRepository = new();
			var nombreCiudad = "Santa Cruz";
			var pais = new PaisFactory().Crear("Bolivia", "555");
			_paisRepository.Setup(_paisRepository => _paisRepository.FindByIdAsync(pais.Id))
				.ReturnsAsync(pais);
			var ciudadFactory = new CiudadFactory(_paisRepository.Object);
			var ciudad = ciudadFactory.Crear(nombreCiudad, pais.Id);
			return ciudad.Result;
		}
	}
}
