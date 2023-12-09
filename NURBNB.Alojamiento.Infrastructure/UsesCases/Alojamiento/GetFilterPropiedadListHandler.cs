using MediatR;
using NURBNB.Alojamiento.Application.Dto.Propiedad;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Query;
using NURBNB.Alojamiento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.UsesCases.Alojamiento
{
	public class GetFilterPropiedadListHandler : IRequestHandler<IGetFilterPropiedadQueryList, ICollection<PropiedadDto>>
	{
		private readonly IPropiedadRepository _propiedadRepository;

		public GetFilterPropiedadListHandler(IPropiedadRepository propiedadRepository)
		{
			_propiedadRepository = propiedadRepository;
		}
		public async Task<ICollection<PropiedadDto>> Handle(IGetFilterPropiedadQueryList request, CancellationToken cancellationToken)
		{
			var propiedades = _propiedadRepository.FindByFilters(request.CiudadId, request.FechaEntrada, request.FechaSalida).Result;
			var propiedadesDTO = propiedades.Select(propiedad => MapperPropiedadDto.MapToPropiedadDto(propiedad)).ToList();
			return propiedadesDTO;
		}
	}
}
