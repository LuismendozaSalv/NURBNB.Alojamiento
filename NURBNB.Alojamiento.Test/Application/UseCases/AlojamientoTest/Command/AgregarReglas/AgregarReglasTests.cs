using Moq;
using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarFotos;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarReglasPropiedad;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.CrearPropiedad;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.AgregarReglas
{
	public class AgregarReglasTests
	{
		Mock<IPropiedadRepository> _propiedadRepository;
		Mock<IUnitOfWork> _unitOfWork;

		public AgregarReglasTests()
		{
			_propiedadRepository = new Mock<IPropiedadRepository>();
			_unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public void AgregarReglasAPropiedadConValoresCorrectos()
		{
			//Arrange
			var propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			var reglas = new List<ReglaDto>() {
				new ReglaDto { Value = "Los huéspedes deben respetar las horas de registro y salida" },
				new ReglaDto { Value = "No se permite el comportamiento violento, el acoso o el vandalismo" }
			};

			_propiedadRepository.Setup(_propiedadRepository => _propiedadRepository.FindByIdAsync(propiedad.Id))
				.ReturnsAsync(propiedad);

			var handler = new AgregarReglasPropiedadHandler(
				_propiedadRepository.Object,
				_unitOfWork.Object
			);
			var tcs = new CancellationTokenSource(1000);
			AgregarReglasPropiedadCommand evento = new AgregarReglasPropiedadCommand
			{
				PropiedadId = propiedad.Id,
				Reglas = reglas
			};
			//Act
			var propiedadId = handler.Handle(evento, tcs.Token);
			//Assert
			Assert.Equal(propiedad.Id, propiedadId.Result);
			Assert.Equal(reglas.Select(regla => regla.Value).ToList(), propiedad.Reglas.Select(regla => regla.Value).ToList());
		}

		[Fact]
		public void AgregarReglasAPropiedadNoExistente()
		{
			//Arrange
			var propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			var reglas = new List<ReglaDto>() {
				new ReglaDto { Value = "Los huéspedes deben respetar las horas de registro y salida" },
				new ReglaDto { Value = "No se permite el comportamiento violento, el acoso o el vandalismo" }
			};

			var handler = new AgregarReglasPropiedadHandler(
				_propiedadRepository.Object,
				_unitOfWork.Object
			);
			var tcs = new CancellationTokenSource(1000);
			AgregarReglasPropiedadCommand evento = new AgregarReglasPropiedadCommand
			{
				PropiedadId = propiedad.Id,
				Reglas = reglas
			};
			//Act
			var propiedadId = handler.Handle(evento, tcs.Token);
			//Assert
			Assert.NotEqual(propiedad.Id, propiedadId.Result);
		}
	}
}
