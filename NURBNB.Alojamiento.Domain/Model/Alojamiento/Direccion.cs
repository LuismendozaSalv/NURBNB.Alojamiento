using NURBNB.Alojamiento.Domain.Rules;
using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
    public class Direccion : Entity
    {
        public Guid PropiedadId { get; private set; }
        public string Street { get; init; }
        public string Avenue { get; init; }
        public string Reference { get; init; }
        public double Latitud { get; init; }
        public double Longitud { get; init; }
        public Ciudad Ciudad { get; private set; }

        internal Direccion()
        {

        }
        internal Direccion(Guid propiedadId, string street, string avenue, string reference, 
            double latitud, double longitud, Ciudad ciudad)
        {
            CheckRule(new StringNotNullOrEmptyRule(street));
            CheckRule(new StringNotNullOrEmptyRule(avenue));
            CheckRule(new StringNotNullOrEmptyRule(reference));
            CheckRule(new IsValidCoordinate(latitud, longitud));
            PropiedadId = propiedadId;
            Street = street;
            Avenue = avenue;
            Reference = reference;
            Latitud = latitud;
            Longitud = longitud;
            Ciudad = ciudad;
        }
    }
}
