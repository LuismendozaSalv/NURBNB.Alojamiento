using Restaurant.SharedKernel.Core;

namespace NURBNB.Alojamiento.Domain.ValueObjects
{
	public record Precio : ValueObject
	{
		public decimal Value { get; init; }

		public Precio(decimal value)
		{
			if (value <= 0)
			{
				throw new ArgumentException("El precio no puede ser cero");
			}
			Value = value;
		}

		public static implicit operator decimal(Precio precio) => precio.Value;

		public static implicit operator Precio(decimal value) => new(value);
	}
}
