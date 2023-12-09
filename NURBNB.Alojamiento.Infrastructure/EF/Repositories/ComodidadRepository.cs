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
	public class ComodidadRepository : IComodidadRepository
	{
		private readonly WriteDbContext _context;

		public ComodidadRepository(WriteDbContext context)
		{
			_context = context;
		}
		public async Task CreateAsync(Comodidad obj)
		{
			await _context.Comodidad.AddAsync(obj);
		}

		public async Task<Comodidad?> FindByIdAsync(Guid id)
		{
			return await _context.Comodidad.FindAsync(id);
		}

		public Task UpdateAsync(Comodidad comodidad)
		{
			_context.Comodidad.Update(comodidad);
			return Task.CompletedTask;
		}
	}
}
