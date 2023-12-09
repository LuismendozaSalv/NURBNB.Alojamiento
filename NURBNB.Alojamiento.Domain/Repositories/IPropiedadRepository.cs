using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Repositories
{
	public interface IPropiedadRepository : IRepository<Propiedad, Guid>
	{
		Task<List<Propiedad>> FindAll();
		Task<List<Propiedad>> FindByCityName(string cityName);
		Task<Propiedad?> FindByReserva(Guid idReserva);
		Task<List<Propiedad>> FindByFilters(Guid ciudadId, DateTime fechaEntrada, DateTime fechaSalida);

		Task<List<Propiedad>> FindByUsuarioId(Guid usuarioId);
		Task<List<Propiedad>> FindByIds(List<Guid> ids);
		Task UpdateAsync(Propiedad Propiedad);
	}
}
