using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Repositories
{
	public interface IEntityRepository<T, in TId> where T : Entity
	{
		Task<T?> FindByIdAsync(TId id);

		Task CreateAsync(T obj);
	}
}
