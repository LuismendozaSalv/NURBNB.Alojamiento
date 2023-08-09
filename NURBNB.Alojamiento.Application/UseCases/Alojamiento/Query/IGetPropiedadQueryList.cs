using MediatR;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;

namespace NURBNB.Alojamiento.Application.UseCases.Alojamiento.Query
{
    public class IGetPropiedadQueryList : IRequest<ICollection<Propiedad>>
    {
        public string? CiudadTerm { get; set; }
    }
}
