using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.Repositories
{
	internal class PropiedadComodidadRepository : IPropiedadComodidadRepository
	{
		private readonly WriteDbContext _context;

		public PropiedadComodidadRepository(WriteDbContext context)
		{
			_context = context;
		}
		public async Task CreateAsync(PropiedadComodidad obj)
		{
			await _context.PropiedadComodidad.AddAsync(obj);
		}

		public Task<PropiedadComodidad?> FindByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(PropiedadComodidad propiedadComodidad)
		{
			_context.PropiedadComodidad.Update(propiedadComodidad);
			return Task.CompletedTask;
		}
	}
}
