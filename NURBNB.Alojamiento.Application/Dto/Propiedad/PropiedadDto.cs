using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.Dto.Propiedad
{
	public class PropiedadDto
	{
		public Guid Id { get; set; }
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public decimal Precio { get; set; }
		public int Personas { get; set; }
		public int Camas { get; set; }
		public int Habitaciones { get; set; }

		public string TipoPropiedad { get; set; }
		public IList<FotoDto> Fotos { get; set; }
	}
}
