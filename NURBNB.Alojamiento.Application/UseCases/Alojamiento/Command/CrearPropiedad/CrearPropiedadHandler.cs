using MediatR;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.CrearAlojamiento
{
	public class CrearPropiedadHandler : IRequestHandler<CrearPropiedadCommand, Guid>
	{
		private IPropiedadRepository _propiedadRepository;
		private IPropiedadFactory _propiedadFactory;
		private IUnitOfWork _unitOfWork;

		public CrearPropiedadHandler(IPropiedadRepository propiedadRepository,
			IPropiedadFactory propiedadFactory,
			IUnitOfWork unitOfWork)
		{
			_propiedadFactory = propiedadFactory;
			_propiedadRepository = propiedadRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(CrearPropiedadCommand request, CancellationToken cancellationToken)
		{
			Propiedad propiedadCreada = null;
			TipoPropiedad tipoPropiedad = (TipoPropiedad)request.TipoPropiedad;
			switch (tipoPropiedad)
			{
				case (TipoPropiedad)Dto.Propiedad.TipoPropiedad.Casa:
					propiedadCreada = _propiedadFactory.CreatePropiedadCasa(request.Titulo, request.Descripcion, request.Precio, request.Personas,
						request.Camas, request.Habitaciones, request.UsuarioId);
					break;
				case (TipoPropiedad)Dto.Propiedad.TipoPropiedad.Apartamento:
					propiedadCreada = _propiedadFactory.CreatePropiedadApartamento(request.Titulo, request.Descripcion, request.Precio,
						request.Personas, request.Camas, request.Habitaciones, request.UsuarioId);
					break;
				case (TipoPropiedad)Dto.Propiedad.TipoPropiedad.Habitacion:
					propiedadCreada = _propiedadFactory.CreatePropiedadHabitacion(request.Titulo, request.Descripcion, request.Precio,
						request.Personas, request.Camas, request.Habitaciones, request.UsuarioId);
					break;
			}
			await _propiedadRepository.CreateAsync(propiedadCreada);

			await _unitOfWork.Commit();

			return propiedadCreada.Id;
		}
	}
}
