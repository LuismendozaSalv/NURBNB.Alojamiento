using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Comodidad.AgregarComodidad.Command
{
	public class CrearComodidadCommand : IRequest<Guid>
	{
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
	}
}
