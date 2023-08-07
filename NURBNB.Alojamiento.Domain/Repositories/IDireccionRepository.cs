using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Repositories
{
    public interface IDireccionRepository : IEntityRepository<Direccion, Guid>
    {
        Task UpdateAsync(Direccion direccion);
    }
}
