using NURBNB.Alojamiento.Domain.Model.Alojamiento;

namespace NURBNB.Alojamiento.Domain.Factories
{
    public class PropiedadFactory : IPropiedadFactory
    {
        public Propiedad CreatePropiedadApartamento(string titulo, string descripcion, decimal precio, int personas, int camas, int habitaciones)
        {
            var capacidad = new Capacidad(personas, camas, habitaciones);
            return new Propiedad(titulo, descripcion, TipoPropiedad.Apartamento, precio, capacidad);
        }

        public Propiedad CreatePropiedadCasa(string titulo, string descripcion, decimal precio, int personas, int camas, int habitaciones)
        {
            var capacidad = new Capacidad(personas, camas, habitaciones);
            return new Propiedad(titulo, descripcion, TipoPropiedad.Casa, precio, capacidad);
        }

        public Propiedad CreatePropiedadHabitacion(string titulo, string descripcion, decimal precio, int personas, int camas, int habitaciones)
        {
            var capacidad = new Capacidad(personas, camas, habitaciones);
            return new Propiedad(titulo, descripcion, TipoPropiedad.Habitacion, precio, capacidad);
        }
    }
}
