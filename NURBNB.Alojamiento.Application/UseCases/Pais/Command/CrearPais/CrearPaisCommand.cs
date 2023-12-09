using MediatR;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Pais.Command.CrearPais
{
	public class CrearPaisCommand : IRequest<Guid>
	{
		public string Nombre { get; set; }
		public string CodigoPais
		{ get; set; }
	}
}
