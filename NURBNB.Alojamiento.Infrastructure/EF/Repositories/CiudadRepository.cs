using Microsoft.EntityFrameworkCore;
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
	internal class CiudadRepository : ICiudadRepository
	{
		private readonly WriteDbContext _context;

		public CiudadRepository(WriteDbContext context)
		{
			_context = context;
		}
		public async Task CreateAsync(Ciudad obj)
		{
			await _context.Ciudad.AddAsync(obj);
		}

		public async Task<Ciudad?> FindByIdAsync(Guid id)
		{
			return await _context.Ciudad.Include(x => x.Country)
				.Where(x => x.Id == id).AsSplitQuery().FirstOrDefaultAsync();
		}

		public Task UpdateAsync(Ciudad ciudad)
		{
			_context.Ciudad.Update(ciudad);
			return Task.CompletedTask;
		}
	}
}
