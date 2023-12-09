using MediatR;
using NURBNB.Alojamiento.Application.Dto.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Query
{
	public class IGetFilterPropiedadQueryList : IRequest<ICollection<PropiedadDto>>
	{
		public Guid CiudadId { get; set; }
		public DateTime FechaEntrada { get; set; }
		public DateTime FechaSalida { get; set; }
	}
}
