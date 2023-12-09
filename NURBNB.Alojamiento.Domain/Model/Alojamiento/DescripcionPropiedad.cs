using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
	public record DescripcionPropiedad : ValueObject
	{
		public string Value { get; init; }

		public DescripcionPropiedad(string value)
		{
			if (string.IsNullOrEmpty(value)) throw new ArgumentException("La descripción no puede estar vacía");
			if (value.Length > 250) throw new ArgumentException("La descripción no puede tener más de 250 caracteres");
			Value = value;
		}

		public static implicit operator string(DescripcionPropiedad descripcionPropiedad) => descripcionPropiedad.Value;
		public static implicit operator DescripcionPropiedad(string descripcionPropiedad) => new(descripcionPropiedad);
	}
}
