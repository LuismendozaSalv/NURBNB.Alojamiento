using MediatR;
using NURBNB.Alojamiento.Application.Dto.Propiedad;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Query
{
	public class IGetPropiedadQueryList : IRequest<ICollection<PropiedadDto>>
	{
		public string? CiudadTerm { get; set; }
	}
}
