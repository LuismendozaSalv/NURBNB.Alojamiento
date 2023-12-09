using MediatR;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarFotos
{
	public class AgregarFotosPropiedadHandler : IRequestHandler<AgregarFotosPropiedadCommand, Guid>
	{
		private IPropiedadRepository _propiedadRepository;
		private IUnitOfWork _unitOfWork;

		public AgregarFotosPropiedadHandler(IPropiedadRepository propiedadRepository,
			IUnitOfWork unitOfWork)
		{
			_propiedadRepository = propiedadRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(AgregarFotosPropiedadCommand request, CancellationToken cancellationToken)
		{

			var propiedad = await _propiedadRepository.FindByIdAsync(request.PropiedadId);
			if (propiedad != null)
			{
				request.Fotos.ForEach(foto =>
				{
					propiedad.AgregarFoto(foto.Url);
				});
				await _propiedadRepository.UpdateAsync(propiedad);
				await _unitOfWork.Commit();
				return propiedad.Id;
			}
			return Guid.NewGuid();
		}
	}
}
