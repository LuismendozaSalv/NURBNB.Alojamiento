using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarDireccionPropiedad
{
	public class AgregarDireccionPropiedadCommand : IRequest<Guid>
	{
		public Guid PropiedadId { get; set; }
		public string Calle { get; set; }
		public string Avenida { get; set; }
		public string Referencia { get; set; }
		public double Latitud { get; set; }
		public double Longitud { get; set; }
		public Guid CiudadId { get; set; }
	}
}
