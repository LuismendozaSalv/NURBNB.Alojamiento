using MediatR;
using NURBNB.Alojamiento.Application.Dto.Propiedad;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.CrearAlojamiento
{
	public class CrearPropiedadCommand : IRequest<Guid>
	{
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public decimal Precio { get; set; }
		public TipoPropiedad TipoPropiedad { get; set; }
		public int Personas { get; set; }
		public int Camas { get; set; }
		public int Habitaciones { get; set; }
		public Guid UsuarioId { get; set; }
	}
}
