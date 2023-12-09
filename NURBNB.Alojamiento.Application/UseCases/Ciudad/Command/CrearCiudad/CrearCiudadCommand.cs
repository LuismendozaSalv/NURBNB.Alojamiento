using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Ciudad.Command.CrearCiudad
{
	public class CrearCiudadCommand : IRequest<Guid>
	{
		public string Nombre { get; set; }
		public Guid PaisId { get; set; }
	}
}
