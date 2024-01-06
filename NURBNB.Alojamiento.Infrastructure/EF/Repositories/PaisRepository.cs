using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Infrastructure.EF.Context;

namespace NURBNB.Alojamiento.Infrastructure.EF.Repositories
{
	internal class PaisRepository : IPaisRepository
	{
		private readonly WriteDbContext _context;

		public PaisRepository(WriteDbContext context)
		{
			_context = context;
		}
		public async Task CreateAsync(Pais obj)
		{
			await _context.Pais.AddAsync(obj);
		}

		public async Task<Pais?> FindByIdAsync(Guid id)
		{
			return await _context.Pais.SingleOrDefaultAsync(x => x.Id == id);
		}

		public Task UpdateAsync(Pais pais)
		{
			_context.Pais.Update(pais);
			return Task.CompletedTask;
		}
	}
}
