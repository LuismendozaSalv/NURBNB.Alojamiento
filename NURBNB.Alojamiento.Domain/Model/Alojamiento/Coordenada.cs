using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Domain.Rules;
using Restaurant.SharedKernel.Core;
using System.ComponentModel.DataAnnotations;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
    [Keyless]
    public record Coordenada : ValueObject
    {
        public double Latitud { get; init; }
        public double Longitud { get; init; }

        public Coordenada(double latitud, double longitud)
        {
            CheckRule(new IsValidCoordinate(latitud, longitud));
            Latitud = latitud;
            Longitud = longitud;
        }

        public static implicit operator (double, double)(Coordenada coordinate)
        {
            return (coordinate.Latitud, coordinate.Longitud);
        }
    }
}
