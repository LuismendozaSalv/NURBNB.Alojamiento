using NURBNB.Alojamiento.Domain.Rules;
using Restaurant.SharedKernel.Core;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
    public record Foto : ValueObject
    {
        public string Url { get; init; }

        public Foto(string url)
        {
            CheckRule(new IsValidUrl(url));
            Url = url;
        }

        public static implicit operator string(Foto foto) => foto.Url;

        public static implicit operator Foto(string url) => new(url);
    }
}
