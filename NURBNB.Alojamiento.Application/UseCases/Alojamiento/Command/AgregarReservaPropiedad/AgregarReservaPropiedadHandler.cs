using MediatR;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarComodidadesPropiedad;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarFotos;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarReservaPropiedad
{
	public class AgregarReservaPropiedadHandler : IRequestHandler<AgregarReservaPropiedadCommand, Guid>
	{
		private IPropiedadRepository _propiedadRepository;
		private IUnitOfWork _unitOfWork;

		public AgregarReservaPropiedadHandler(IPropiedadRepository propiedadRepository,
			IUnitOfWork unitOfWork)
		{
			_propiedadRepository = propiedadRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(AgregarReservaPropiedadCommand request, CancellationToken cancellationToken)
		{

			var propiedad = await _propiedadRepository.FindByIdAsync(request.PropiedadId);
			if (propiedad != null)
			{
				var reserva = new ReservaFactory().Crear(request.ReservaId,
					request.FechaEntrada,
					request.FechaSalida,
					(EstadoReserva)request.Estado);
				propiedad.AgregarReserva(reserva);
				await _propiedadRepository.UpdateAsync(propiedad);
				await _unitOfWork.Commit();
				return propiedad.Id;
			}
			return Guid.NewGuid();
		}

	}
}
