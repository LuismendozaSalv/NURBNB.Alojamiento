using Moq;
using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarComodidadesPropiedad;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.CrearPropiedad;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.CrearComodidad
{
	public class CrearComodidadTests
	{
		Mock<IPropiedadRepository> _propiedadRepository;
		Mock<IPropiedadComodidadRepository> _propiedadComodidadRepository;
		Mock<IUnitOfWork> _unitOfWork;

		public CrearComodidadTests()
		{
			_propiedadRepository = new Mock<IPropiedadRepository>();
			_propiedadComodidadRepository = new Mock<IPropiedadComodidadRepository>();
			_unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public void AgregarComodidadesAPropiedadConValoresCorrectos()
		{
			//Arrange
			var propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			var listaComodidades = ComodidadMockFactory.ObtenerComodidades();

			_propiedadRepository.Setup(_propiedadRepository => _propiedadRepository.FindByIdAsync(propiedad.Id))
				.ReturnsAsync(propiedad);

			var handler = new AgregarComodidadesPropiedadHandler(
				_propiedadRepository.Object,
				_unitOfWork.Object,
				_propiedadComodidadRepository.Object
			);
			var tcs = new CancellationTokenSource(1000);
			AgregarComodidadesPropiedadCommand evento = new AgregarComodidadesPropiedadCommand
			{
				PropiedadId = propiedad.Id,
				Comodidades = listaComodidades.Select(comodidad => comodidad.Id).ToList()
			};
			//Act
			var propiedadId = handler.Handle(evento, tcs.Token);
			//Assert
			Assert.Equal(propiedad.Id, propiedadId.Result);
		}

		[Fact]
		public void AgregarComodidadesAPropiedadNoExistente()
		{
			//Arrange
			var propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			var listaComodidades = ComodidadMockFactory.ObtenerComodidades();

			var handler = new AgregarComodidadesPropiedadHandler(
				_propiedadRepository.Object,
				_unitOfWork.Object,
				_propiedadComodidadRepository.Object
			);
			var tcs = new CancellationTokenSource(1000);
			AgregarComodidadesPropiedadCommand evento = new AgregarComodidadesPropiedadCommand
			{
				PropiedadId = propiedad.Id,
				Comodidades = listaComodidades.Select(comodidad => comodidad.Id).ToList()
			};
			//Act
			var propiedadId = handler.Handle(evento, tcs.Token);
			//Assert
			Assert.NotEqual(propiedad.Id, propiedadId.Result);
		}
	}
}
