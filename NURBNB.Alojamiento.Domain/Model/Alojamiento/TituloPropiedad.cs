using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
	public record TituloPropiedad : ValueObject
	{
		public string Value { get; init; }

		public TituloPropiedad(string value)
		{
			if (String.IsNullOrEmpty(value)) throw new ArgumentException("El título no puede estar vacío");
			if (value.Length > 100) throw new ArgumentException("El título no puede tener más de 100 caracteres");
			Value = value;
		}

		public static implicit operator string(TituloPropiedad tituloPropiedad) => tituloPropiedad.Value;
		public static implicit operator TituloPropiedad(string tituloPropiedad) => new(tituloPropiedad);
	}
}
