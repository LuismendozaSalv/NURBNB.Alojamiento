using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Repositories
{
	public interface IPaisRepository : IEntityRepository<Pais, Guid>
	{
		Task UpdateAsync(Pais pais);
	}
}
