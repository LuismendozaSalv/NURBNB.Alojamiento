using MediatR;
using NURBNB.Alojamiento.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarComodidadesPropiedad
{
	public class AgregarComodidadesPropiedadCommand : IRequest<Guid>
	{
		public Guid PropiedadId { get; set; }
		public List<Guid> Comodidades { get; set; }
	}
}
