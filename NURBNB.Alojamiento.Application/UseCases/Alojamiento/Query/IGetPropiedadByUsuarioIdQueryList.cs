using MediatR;
using NURBNB.Alojamiento.Application.Dto.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Query
{
	public class IGetPropiedadByUsuarioIdQueryList : IRequest<ICollection<PropiedadDto>>
	{
		public Guid UsuarioId { get; set; }
	}
}
