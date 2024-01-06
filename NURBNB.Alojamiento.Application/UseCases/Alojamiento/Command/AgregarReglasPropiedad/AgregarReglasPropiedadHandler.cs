using MediatR;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarFotos;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarReglasPropiedad
{
	public class AgregarReglasPropiedadHandler : IRequestHandler<AgregarReglasPropiedadCommand, Guid>
	{
		private IPropiedadRepository _propiedadRepository;
		private IUnitOfWork _unitOfWork;

		public AgregarReglasPropiedadHandler(IPropiedadRepository propiedadRepository,
			IUnitOfWork unitOfWork)
		{
			_propiedadRepository = propiedadRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(AgregarReglasPropiedadCommand request, CancellationToken cancellationToken)
		{

			var propiedad = await _propiedadRepository.FindByIdAsync(request.PropiedadId);
			if (propiedad != null)
			{
				request.Reglas.ForEach(regla =>
				{
					propiedad.AgregarRegla(regla.Value);
				});
				await _propiedadRepository.UpdateAsync(propiedad);
				await _unitOfWork.Commit();
				return propiedad.Id;
			}
			return Guid.NewGuid();
		}
	}
}
