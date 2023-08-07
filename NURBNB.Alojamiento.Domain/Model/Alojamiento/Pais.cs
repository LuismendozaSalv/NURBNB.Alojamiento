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
