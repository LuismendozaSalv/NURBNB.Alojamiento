using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
	public class Comodidad : Entity
	{
		public string Nombre { get; private set; }
		public string Descripcion { get; private set; }

		internal Comodidad()
		{

		}
		public Comodidad(string nombre, string descripcion)
		{
			CheckRule(new StringNotNullOrEmptyRule(nombre));
			CheckRule(new StringNotNullOrEmptyRule(descripcion));
			Id = Guid.NewGuid();
			Nombre = nombre;
			Descripcion = descripcion;
		}
	}
}
