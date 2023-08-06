using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
    public record Comodidad : ValueObject
    {
        public string Value { get; init; }

        public Comodidad(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            Value = value;
        }

        public static implicit operator string(Comodidad amenity) => amenity.Value;

        public static implicit operator Comodidad(string amenity) => new(amenity);
    }
}
