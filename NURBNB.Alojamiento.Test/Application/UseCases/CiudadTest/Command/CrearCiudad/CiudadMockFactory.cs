using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Test.Application.UseCases.CiudadTest.Command.CrearCiudad
{
    internal class CiudadMockFactory
    {
        public static Ciudad getCiudad()
        {
            var nombreCiudad = "Santa Cruz";
            var pais = new PaisFactory().Crear("Bolivia", "555");
            var ciudad = new Ciudad(nombreCiudad, pais);
            return ciudad;
        }
    }
}
