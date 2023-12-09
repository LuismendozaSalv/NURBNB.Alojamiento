using MediatR;
using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Application.Dto.Propiedad;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Query;
using NURBNB.Alojamiento.Application.UseCases.Pais.Query.GetPaisList;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using NURBNB.Alojamiento.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.UsesCases.Alojamiento
{
	internal class GetPropiedadListHandler : IRequestHandler<IGetPropiedadQueryList, ICollection<PropiedadDto>>
	{
		private readonly IPropiedadRepository _propiedadRepository;

		public GetPropiedadListHandler(IPropiedadRepository propiedadRepository)
		{
			_propiedadRepository = propiedadRepository;
		}

		public async Task<ICollection<PropiedadDto>> Handle(IGetPropiedadQueryList request, CancellationToken cancellationToken)
		{

			if (!string.IsNullOrWhiteSpace(request.CiudadTerm))
			{

				var propiedades = _propiedadRepository.FindByCityName(request.CiudadTerm).Result;
				var propiedadesDTO = propiedades.Select(propiedad => MapperPropiedadDto.MapToPropiedadDto(propiedad)).ToList();
				return propiedadesDTO;
			}

			return new List<PropiedadDto>();
		}
	}
}
