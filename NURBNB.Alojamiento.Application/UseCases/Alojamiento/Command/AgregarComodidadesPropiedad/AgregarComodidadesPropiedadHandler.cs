using MediatR;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarComodidadesPropiedad
{
	public class AgregarComodidadesPropiedadHandler : IRequestHandler<AgregarComodidadesPropiedadCommand, Guid>
	{
		private IPropiedadRepository _propiedadRepository;
		private IPropiedadComodidadRepository _propiedadComodidadRepository;
		private IUnitOfWork _unitOfWork;

		public AgregarComodidadesPropiedadHandler(IPropiedadRepository propiedadRepository,
			IUnitOfWork unitOfWork,
			IPropiedadComodidadRepository propiedadComodidadRepository)
		{
			_propiedadRepository = propiedadRepository;
			_unitOfWork = unitOfWork;
			_propiedadComodidadRepository = propiedadComodidadRepository;
		}

		public async Task<Guid> Handle(AgregarComodidadesPropiedadCommand request, CancellationToken cancellationToken)
		{
			var propiedad = await _propiedadRepository.FindByIdAsync(request.PropiedadId);
			if (propiedad != null)
			{
				request.Comodidades.ForEach(comodidadId =>
				{
					propiedad.AgregarComodidad(comodidadId);
				});
				propiedad.Comodidades.ToList().ForEach(comodidad =>
				{
					_propiedadComodidadRepository.CreateAsync(comodidad);
				});
				await _propiedadRepository.UpdateAsync(propiedad);
				await _unitOfWork.Commit();
				return propiedad.Id;
			}
			return Guid.NewGuid();
		}
	}
}
