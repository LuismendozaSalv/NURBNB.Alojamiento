using Moq;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Command.CrearCiudad;
using NURBNB.Alojamiento.Application.UseCases.Comodidad.AgregarComodidad.Command;
using NURBNB.Alojamiento.Application.UseCases.Comodidad.CrearComodidad.Command;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.CrearComodidad;
using NURBNB.Alojamiento.Test.Application.UseCases.CiudadTest.Command.CrearCiudad;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.ComodidadTest.Command
{
	public class CrearComodidadHandlerTests
	{
		Mock<IComodidadRepository> _comodidadRepository;
		Mock<IComodidadFactory> _comodidadFactory;
		Mock<IUnitOfWork> _unitOfWork;

		public CrearComodidadHandlerTests()
		{
			_comodidadRepository = new Mock<IComodidadRepository>();
			_comodidadFactory = new Mock<IComodidadFactory>();
			_unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public void CrearComodidadConValoresValidos()
		{
			Comodidad comodidad = ComodidadMockFactory.ObtenerComodidad();

			_comodidadRepository.Setup(_comodidadRepository => _comodidadRepository.FindByIdAsync(comodidad.Id))
				.ReturnsAsync(comodidad);
			_comodidadFactory.Setup(_comodidadFactory => _comodidadFactory.Crear(comodidad.Nombre, comodidad.Descripcion))
				.Returns(comodidad);
			var handler = new CrearComodidadHandler(
				_comodidadRepository.Object,
				_unitOfWork.Object,
				_comodidadFactory.Object
			);
			var tcs = new CancellationTokenSource(1000);

			CrearComodidadCommand evento = new CrearComodidadCommand
			{
				Nombre = comodidad.Nombre,
				Descripcion = comodidad.Descripcion,
			};

			var idComodidad = handler.Handle(evento, tcs.Token);

			Assert.Equal(comodidad.Id, idComodidad.Result);
		}
	}
}
