using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.Dto
{
	public class CiudadDto
	{
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public Guid PaisId { get; set; }
		public string NombrePais { get; set; }
	}
}
