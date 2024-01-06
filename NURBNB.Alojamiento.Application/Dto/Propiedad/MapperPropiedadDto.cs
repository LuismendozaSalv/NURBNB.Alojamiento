namespace NURBNB.Alojamiento.Application.Dto.Propiedad
{
	public static class MapperPropiedadDto
	{
		public static PropiedadDto MapToPropiedadDto(Domain.Model.Alojamiento.Propiedad propiedad)
		{
			return new PropiedadDto
			{
				Id = propiedad.Id,
				Titulo = propiedad.Titulo,
				Descripcion = propiedad.Descripcion,
				Precio = propiedad.Precio,
				Camas = propiedad.Capacidad.Beds,
				Personas = propiedad.Capacidad.People,
				Habitaciones = propiedad.Capacidad.Rooms,
				TipoPropiedad = propiedad.TipoPropiedad.ToString(),
				Fotos = propiedad.Fotos.Select(foto => new FotoDto { Url = foto.Url }).ToList()
			};
		}
	}
}
