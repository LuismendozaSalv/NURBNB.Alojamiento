using MediatR;
using NURBNB.Alojamiento.Application.Dto;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarFotos
{
	public class AgregarFotosPropiedadCommand : IRequest<Guid>
	{

		public Guid PropiedadId { get; set; }
		public List<FotoDto> Fotos { get; set; }
	}
}
