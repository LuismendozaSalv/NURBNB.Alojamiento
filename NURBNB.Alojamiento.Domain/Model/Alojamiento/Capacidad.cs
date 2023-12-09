using NURBNB.Alojamiento.Domain.Rules;
using Restaurant.SharedKernel.Core;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
	public record Capacidad : ValueObject
	{
		public int People { get; init; }
		public int Beds { get; init; }
		public int Rooms { get; init; }

		public Capacidad(int people, int beds, int rooms)
		{
			if (people <= 0) throw new ArgumentException("La capacidad de personas debe ser mayor a cero");
			if (beds <= 0) throw new ArgumentException("La capacidad de camas debe ser mayor a cero");
			if (rooms <= 0) throw new ArgumentException("La capacidad de habitaciones debe ser mayor a cero");
			People = people;
			Beds = beds;
			Rooms = rooms;
		}
	}
}
