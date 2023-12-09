using Moq;
using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarDireccionPropiedad;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarFotos;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.AgregarDireccion;
using NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.CrearPropiedad;
using NURBNB.Alojamiento.Test.Application.UseCases.CiudadTest.Command.CrearCiudad;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.AgregarFotos
{
	public class AgregarFotosTests
	{
		Mock<IPropiedadRepository> _propiedadRepository;
		Mock<IUnitOfWork> _unitOfWork;

		public AgregarFotosTests()
		{
			_propiedadRepository = new Mock<IPropiedadRepository>();
			_unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public void AgregarFotosAPropiedadConValoresCorrectos()
		{
			//Arrange
			var propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			var fotos = new List<FotoDto>() {
				new FotoDto { Url = "https://cdn.pixabay.com/photo/2014/12/22/10/04/lions-577104_1280.jpg" },
				new FotoDto { Url =  "https://i.pinimg.com/564x/46/4b/42/464b42dc572c35a579d4c8b8e7c99dc2.jpg" }
			};

			_propiedadRepository.Setup(_propiedadRepository => _propiedadRepository.FindByIdAsync(propiedad.Id))
				.ReturnsAsync(propiedad);

			var handler = new AgregarFotosPropiedadHandler(
				_propiedadRepository.Object,
				_unitOfWork.Object
			);
			var tcs = new CancellationTokenSource(1000);
			AgregarFotosPropiedadCommand evento = new AgregarFotosPropiedadCommand
			{
				PropiedadId = propiedad.Id,
				Fotos = fotos
			};
			//Act
			var propiedadId = handler.Handle(evento, tcs.Token);
			//Assert
			Assert.Equal(propiedad.Id, propiedadId.Result);
			Assert.Equal(fotos.Select(foto => foto.Url).ToList(), propiedad.Fotos.Select(foto => foto.Url).ToList());
		}

		[Fact]
		public void AgregarFotosAPropiedadNoExistente()
		{
			//Arrange
			var propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			var fotos = new List<FotoDto>() {
				new FotoDto { Url = "https://cdn.pixabay.com/photo/2014/12/22/10/04/lions-577104_1280.jpg" },
				new FotoDto { Url =  "https://i.pinimg.com/564x/46/4b/42/464b42dc572c35a579d4c8b8e7c99dc2.jpg" }
			};

			var handler = new AgregarFotosPropiedadHandler(
				_propiedadRepository.Object,
				_unitOfWork.Object
			);
			var tcs = new CancellationTokenSource(1000);
			AgregarFotosPropiedadCommand evento = new AgregarFotosPropiedadCommand
			{
				PropiedadId = propiedad.Id,
				Fotos = fotos
			};
			//Act
			var propiedadId = handler.Handle(evento, tcs.Token);
			//Assert
			Assert.NotEqual(propiedad.Id, propiedadId.Result);
		}
	}
}
