using MediatR;
using NURBNB.Alojamiento.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarReglasPropiedad
{
	public class AgregarReglasPropiedadCommand : IRequest<Guid>
	{
		public Guid PropiedadId { get; set; }
		public List<ReglaDto> Reglas { get; set; }
	}
}
