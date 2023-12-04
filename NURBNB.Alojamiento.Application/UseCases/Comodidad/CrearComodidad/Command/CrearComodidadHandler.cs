using MediatR;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Command.CrearCiudad;
using NURBNB.Alojamiento.Application.UseCases.Comodidad.AgregarComodidad.Command;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Comodidad.CrearComodidad.Command
{
	public class CrearComodidadHandler : IRequestHandler<CrearComodidadCommand, Guid>
	{
		private IComodidadRepository _comodidadRepository;
		private IComodidadFactory _comodidadFactory;
		private IUnitOfWork _unitOfWork;

		public CrearComodidadHandler(IComodidadRepository comodidadRepository,
			IUnitOfWork unitOfWork,
			IComodidadFactory comodidadFactory)
		{
			_comodidadRepository = comodidadRepository;
			_unitOfWork = unitOfWork;
			_comodidadFactory = comodidadFactory;
		}

		public async Task<Guid> Handle(CrearComodidadCommand request, CancellationToken cancellationToken)
		{
			var comodidadCreada = _comodidadFactory.Crear(request.Nombre, request.Descripcion);

			await _comodidadRepository.CreateAsync(comodidadCreada);

			await _unitOfWork.Commit();

			return comodidadCreada.Id;
		}
	}
}
