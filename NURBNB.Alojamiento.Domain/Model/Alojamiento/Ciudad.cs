using Restaurant.SharedKernel.Core;

namespace NURBNB.Alojamiento.Domain.Model.Alojamiento
{
    public class Ciudad : Entity
    {
        public string Name { get; private set; }
        public Pais Country { get; private set; }

        private Ciudad() { }
        public Ciudad(string name, Pais country)
        {
            Id = Guid.NewGuid();
            Name = name;
            Country = country;
        }
    }
}
