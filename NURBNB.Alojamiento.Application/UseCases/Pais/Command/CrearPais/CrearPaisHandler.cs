using MediatR;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Pais.Command.CrearPais
{

	public class CrearPaisHandler : IRequestHandler<CrearPaisCommand, Guid>
	{
		private IPaisRepository _paisRepository;
		private IPaisFactory _paisFactory;
		private IUnitOfWork _unitOfWork;

		public CrearPaisHandler(IPaisRepository paisRepository,
			IPaisFactory paisFactory,
			IUnitOfWork unitOfWork)
		{
			_paisRepository = paisRepository;
			_paisFactory = paisFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CrearPaisCommand request, CancellationToken cancellationToken)
		{
			var paisCreado = _paisFactory.Crear(request.Nombre, request.CodigoPais);

			await _paisRepository.CreateAsync(paisCreado);

			await _unitOfWork.Commit();

			return paisCreado.Id;
		}
	}
}
