using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
	public class PropiedadComodidad : Entity
	{
		public Guid ComodidadId { get; private set; }

		private PropiedadComodidad()
		{

		}
		public PropiedadComodidad(Guid comodidadId)
		{
			Id = Guid.NewGuid();
			ComodidadId = comodidadId;
		}
	}
}
