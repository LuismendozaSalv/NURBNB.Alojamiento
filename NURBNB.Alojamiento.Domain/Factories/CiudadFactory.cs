using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Factories
{
    public class CiudadFactory : ICiudadFactory
    {
        public Ciudad Crear(string nombre, Guid PaisId)
        {
            return new Ciudad(nombre, new Pais("Bolivia", "591"));
        }
    }
}
