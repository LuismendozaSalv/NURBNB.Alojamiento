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
	public class DireccionRepository : IDireccionRepository
	{
		private readonly WriteDbContext _context;
		public DireccionRepository(WriteDbContext context)
		{
			_context = context;
		}
		public async Task CreateAsync(Direccion obj)
		{
			await _context.Direccion.AddAsync(obj);
		}

		public async Task<List<Direccion>> FindAll()
		{
			return await _context.Direccion
				.Include(d => d.Ciudad)
					.ToListAsync();
		}

		public async Task<Direccion?> FindByIdAsync(Guid id)
		{
			return await _context.Direccion.FindAsync(id);
		}

		public async Task<List<Direccion>> FindByCityName(string name)
		{
			return await _context.Direccion
				.Where(d => d.Ciudad.Name.Equals(name))
				.Include(d => d.Ciudad).ToListAsync();
		}

		public Task UpdateAsync(Direccion direccion)
		{
			_context.Direccion.Update(direccion);
			return Task.CompletedTask;
		}
	}
}
