using MediatR;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarReservaPropiedad;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.ModificarReservaPropiedad
{
	public class ModificarReservaPropiedadHandler : IRequestHandler<ModificarReservaPropiedadCommand, Guid>
	{
		private readonly IPropiedadRepository _propiedadRepository;
		private readonly IUnitOfWork _unitOfWork;

		public ModificarReservaPropiedadHandler(IPropiedadRepository propiedadRepository,
			IUnitOfWork unitOfWork)
		{
			_propiedadRepository = propiedadRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(ModificarReservaPropiedadCommand request, CancellationToken cancellationToken)
		{
			var propiedad = await _propiedadRepository.FindByReserva(request.ReservaId);
			if (propiedad != null)
			{
				var reserva = propiedad.Reservas.FirstOrDefault(reserva => reserva.Id == request.ReservaId);
				if (reserva != null)
				{
					reserva.Editar(request.Estado);
					await _propiedadRepository.UpdateAsync(propiedad);
					await _unitOfWork.Commit();
					return propiedad.Id;
				}
			}
			return Guid.NewGuid();
		}
	}
}
