using Restaurant.SharedKernel.Core;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
	public class Pais : Entity
	{
		public string Name { get; private set; }
		public string CountryCode { get; private set; }
		private readonly IList<Ciudad> _ciudades;
		public IEnumerable<Ciudad> Ciudades => _ciudades;

		private Pais() { }

		public Pais(string name, string countryCode)
		{
			if (String.IsNullOrEmpty(name)) throw new ArgumentException("El nombre no puede estar vacío");
			if (String.IsNullOrEmpty(countryCode)) throw new ArgumentException("El código no puede estar vacío");
			Id = Guid.NewGuid();
			Name = name;
			CountryCode = countryCode;
			_ciudades = new List<Ciudad>();
		}

		public void AgregarCiudad(string NombreCiudad)
		{
			var ciudad = new Ciudad(NombreCiudad, this);

			_ciudades.Add(ciudad);
		}
	}
}
