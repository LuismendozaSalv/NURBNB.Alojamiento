using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
    public record Regla : ValueObject
    {
        public string Value { get; init; }

        public Regla(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            Value = value;
        }

        public static implicit operator string(Regla rule) => rule.Value;

        public static implicit operator Regla(string rule) => new(rule);
    }
}
