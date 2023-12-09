using MediatR;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.CrearAlojamiento;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarDireccionPropiedad
{
	public class AgregarDireccionPropiedadHandler : IRequestHandler<AgregarDireccionPropiedadCommand, Guid>
	{
		private readonly IPropiedadRepository _propiedadRepository;
		private readonly ICiudadRepository _ciudadRepository;
		private readonly IUnitOfWork _unitOfWork;

		public AgregarDireccionPropiedadHandler(IPropiedadRepository propiedadRepository,
			ICiudadRepository ciudadRepository,
			IUnitOfWork unitOfWork)
		{
			_ciudadRepository = ciudadRepository;
			_propiedadRepository = propiedadRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(AgregarDireccionPropiedadCommand request, CancellationToken cancellationToken)
		{
			var ciudad = await _ciudadRepository.FindByIdAsync(request.CiudadId);
			var propiedad = await _propiedadRepository.FindByIdAsync(request.PropiedadId);
			if (propiedad != null && ciudad != null)
			{
				propiedad.AgregarDireccion(request.Calle, request.Avenida, request.Referencia, request.Latitud, request.Longitud, ciudad);
				await _propiedadRepository.UpdateAsync(propiedad);
				await _unitOfWork.Commit();
				return propiedad.Direccion!.Id;
			}
			return Guid.NewGuid();
		}
	}
}
