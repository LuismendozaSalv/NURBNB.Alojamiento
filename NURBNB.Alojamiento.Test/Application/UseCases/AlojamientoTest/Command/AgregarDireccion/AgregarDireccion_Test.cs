using Moq;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarDireccionPropiedad;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.CrearAlojamiento;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.CrearPropiedad;
using NURBNB.Alojamiento.Test.Application.UseCases.CiudadTest.Command.CrearCiudad;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.AgregarDireccion
{
	public class AgregarDireccion_Test
	{
		private readonly Mock<IPropiedadRepository> _propiedadRepository;
		private readonly Mock<ICiudadRepository> _ciudadRepository;
		private readonly Mock<IUnitOfWork> _unitOfWork;

		public AgregarDireccion_Test()
		{
			_ciudadRepository = new Mock<ICiudadRepository>();
			_propiedadRepository = new Mock<IPropiedadRepository>();
			_unitOfWork = new Mock<IUnitOfWork>();
		}

		[Fact]
		public void AgregarDireccionAPropiedad()
		{
			var ciudad = CiudadMockFactory.GetCiudad();
			var propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			var direccion = DireccionMockFactory.addDireccion(propiedad, ciudad).Direccion;
			_ciudadRepository.Setup(_ciudadRepository => _ciudadRepository.FindByIdAsync(ciudad.Id))
				.ReturnsAsync(ciudad);
			_propiedadRepository.Setup(_propiedadRepository => _propiedadRepository.FindByIdAsync(propiedad.Id))
				.ReturnsAsync(propiedad);

			var handler = new AgregarDireccionPropiedadHandler(
				_propiedadRepository.Object,
				_ciudadRepository.Object,
				_unitOfWork.Object
			);
			var tcs = new CancellationTokenSource(1000);
			AgregarDireccionPropiedadCommand evento = new()
			{
				Avenida = direccion!.Avenida,
				Calle = direccion.Calle,
				Latitud = direccion.Latitud,
				Longitud = direccion.Longitud,
				Referencia = direccion.Referencia,
				PropiedadId = propiedad.Id,
				CiudadId = ciudad.Id,
			};

			var direccionId = handler.Handle(evento, tcs.Token);

			Assert.NotNull(direccionId.Result);
		}

		[Fact]
		public void AgregarDireccionAPropiedadNoExistente()
		{
			var ciudad = CiudadMockFactory.GetCiudad();
			var propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			var direccion = DireccionMockFactory.addDireccion(propiedad, ciudad).Direccion;
			_ciudadRepository.Setup(_ciudadRepository => _ciudadRepository.FindByIdAsync(ciudad.Id))
				.ReturnsAsync(ciudad);

			var handler = new AgregarDireccionPropiedadHandler(
				_propiedadRepository.Object,
				_ciudadRepository.Object,
				_unitOfWork.Object
			);
			var tcs = new CancellationTokenSource(1000);
			AgregarDireccionPropiedadCommand evento = new()
			{
				Avenida = direccion!.Avenida,
				Calle = direccion.Calle,
				Latitud = direccion.Latitud,
				Longitud = direccion.Longitud,
				Referencia = direccion.Referencia,
				PropiedadId = propiedad.Id,
				CiudadId = ciudad.Id,
			};

			var direccionId = handler.Handle(evento, tcs.Token);

			Assert.NotEqual(propiedad.Direccion!.Id, direccionId.Result);

		}

		[Fact]
		public void AgregarDireccionAPropiedadConCiudadNoExistente()
		{
			var ciudad = CiudadMockFactory.GetCiudad();
			var propiedad = PropiedadMockFactory.GetPropiedadApartamento();
			var direccion = DireccionMockFactory.addDireccion(propiedad, ciudad).Direccion;
			_propiedadRepository.Setup(_propiedadRepository => _propiedadRepository.FindByIdAsync(propiedad.Id))
				.ReturnsAsync(propiedad);

			var handler = new AgregarDireccionPropiedadHandler(
				_propiedadRepository.Object,
				_ciudadRepository.Object,
				_unitOfWork.Object
			);
			var tcs = new CancellationTokenSource(1000);
			AgregarDireccionPropiedadCommand evento = new()
			{
				Avenida = direccion!.Avenida,
				Calle = direccion.Calle,
				Latitud = direccion.Latitud,
				Longitud = direccion.Longitud,
				Referencia = direccion.Referencia,
				PropiedadId = propiedad.Id,
				CiudadId = ciudad.Id,
			};

			var direccionId = handler.Handle(evento, tcs.Token);

			Assert.NotEqual(propiedad.Direccion!.Id, direccionId.Result);
		}
	}
}
