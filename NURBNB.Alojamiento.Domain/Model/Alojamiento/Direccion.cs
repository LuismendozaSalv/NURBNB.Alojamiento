using NURBNB.Alojamiento.Domain.Rules;
using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
	public class Direccion : Entity
	{
		public Guid PropiedadId { get; private set; }
		public string Calle { get; init; }
		public string Avenida { get; init; }
		public string Referencia { get; init; }
		public double Latitud { get; init; }
		public double Longitud { get; init; }
		public Ciudad Ciudad { get; private set; }

		internal Direccion()
		{

		}
		public Direccion(Guid propiedadId, string calle, string avenida, string referencia,
			double latitud, double longitud, Ciudad ciudad)
		{
			CheckRule(new StringNotNullOrEmptyRule(calle));
			CheckRule(new StringNotNullOrEmptyRule(avenida));
			CheckRule(new StringNotNullOrEmptyRule(referencia));
			CheckRule(new IsValidCoordinate(latitud, longitud));
			Id = Guid.NewGuid();
			PropiedadId = propiedadId;
			Calle = calle;
			Avenida = avenida;
			Referencia = referencia;
			Latitud = latitud;
			Longitud = longitud;
			Ciudad = ciudad;
		}
	}
}
