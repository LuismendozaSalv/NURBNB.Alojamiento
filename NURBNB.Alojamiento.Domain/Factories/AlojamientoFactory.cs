using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Factories
{
    public class AlojamientoFactory : IAlojamientoFactory
    {
        //public Propiedad CreateAlojamientoApartamento(string titulo, string descripcion, string calle, string avenida, string referencia, int personas, int camas, int habitaciones, decimal precio, double latitud, double longitud, Guid ciudadId, List<string> comodidades, List<string> fotos, List<string> reglas, Guid usuarioId)
        //{
        //    var alojamientoInfo = ObtenerAlojamientoInfo(titulo, descripcion, precio, fotos, reglas);
        //    var direccion = ObtenerDireccion(latitud, longitud, calle, avenida, referencia, usuarioId);
        //    var capacidad = new Capacidad(personas, camas, habitaciones);
        //    var alojamiento = new Model.Alojamiento.Propiedad(direccion, capacidad, TipoPropiedad.Apartamento, usuarioId);
        //    comodidades.ForEach(comodidad => {
        //        alojamiento.AgregarComodidad(comodidad);
        //    });
        //    return alojamiento;
        //}

        //public Propiedad CreateAlojamientoCasa(string titulo, string descripcion, string calle, string avenida, string referencia, int personas, int camas, int habitaciones, decimal precio, double latitud, double longitud, Guid ciudadId, List<string> comodidades, List<string> fotos, List<string> reglas, Guid usuarioId)
        //{
        //    var alojamientoInfo = ObtenerAlojamientoInfo(titulo, descripcion, precio, fotos, reglas);
        //    var direccion = ObtenerDireccion(latitud, longitud, calle, avenida, referencia, usuarioId);
        //    var capacidad = new Capacidad(personas, camas, habitaciones);
        //    var alojamiento = new Model.Alojamiento.Propiedad(direccion, capacidad, TipoPropiedad.Casa, usuarioId);
        //    comodidades.ForEach(comodidad => {
        //        alojamiento.AgregarComodidad(comodidad);
        //    });
        //    return alojamiento;
        //}

        //public Propiedad CreateAlojamientoHabitacion(string titulo, string descripcion, string calle, string avenida, string referencia, int personas, int camas, int habitaciones, decimal precio, double latitud, double longitud, Guid ciudadId, List<string> comodidades, List<string> fotos, List<string> reglas, Guid usuarioId)
        //{
        //    var alojamientoInfo = ObtenerAlojamientoInfo(titulo, descripcion, precio, fotos, reglas);
        //    var direccion = ObtenerDireccion(latitud, longitud, calle, avenida, referencia, usuarioId);
        //    var capacidad = new Capacidad(personas, camas, habitaciones);
        //    var alojamiento = new Model.Alojamiento.Propiedad(direccion, capacidad, TipoPropiedad.Habitacion, usuarioId);
        //    comodidades.ForEach(comodidad => {
        //        alojamiento.AgregarComodidad(comodidad);
        //    });
        //    return alojamiento;
        //}

        //public Direccion ObtenerDireccion(double latitud, double longitud, string calle, string avenida, string referencia, Guid ciudadId)
        //{
        //    var coordernada = new Coordenada(latitud, longitud);
        //    //Obtener ciudad
        //    var ciudad = ObtenerCiudadPorId(ciudadId);
        //    var direccion = new Direccion(calle, avenida, referencia, coordernada, ciudad);
        //    return direccion;
        //}

        public Ciudad ObtenerCiudadPorId(Guid ciudadId)
        {
            var ciudad = new Ciudad("Santa Cruz de la Sierra", new Pais("Bolivia", "591"));
            return ciudad;
        }
    }
}
