using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Factories
{
	public interface IPropiedadFactory
	{
		public Propiedad CreatePropiedadApartamento(string titulo, string descripcion, decimal precio,
			int personas, int camas, int habitaciones, Guid usuarioId);
		public Propiedad CreatePropiedadCasa(string titulo, string descripcion, decimal precio,
			int personas, int camas, int habitaciones, Guid usuarioId);
		public Propiedad CreatePropiedadHabitacion(string titulo, string descripcion, decimal precio,
			int personas, int camas, int habitaciones, Guid usuarioId);
	}
}
