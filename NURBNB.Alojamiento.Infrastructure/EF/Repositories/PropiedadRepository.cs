using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using System.Linq;

namespace NURBNB.Alojamiento.Infrastructure.EF.Repositories
{
	internal class PropiedadRepository : IPropiedadRepository
	{
		private readonly WriteDbContext _context;

		public PropiedadRepository(WriteDbContext context)
		{
			_context = context;
		}
		public async Task CreateAsync(Propiedad obj)
		{
			await _context.Propiedad.AddAsync(obj);
		}

		public async Task<List<Propiedad>> FindAll()
		{
			return await _context.Propiedad
				.Include("_comodidades")
				.Include(x => x.Direccion)
					.ThenInclude(direccion => direccion!.Ciudad)
					.ToListAsync();
		}

		public async Task<List<Propiedad>> FindByCityName(string cityName)
		{
			return await _context.Propiedad
				.Include(x => x.Direccion)
					.ThenInclude(direccion => direccion!.Ciudad)
					.Where(propiedad => propiedad.Direccion!.Ciudad.Name.ToLower().Contains(cityName.ToLower()))
					.ToListAsync();
		}

		public async Task<List<Propiedad>> FindByFilters(Guid ciudadId, DateTime fechaEntrada, DateTime fechaSalida)
		{
			var propiedades = _context.Propiedad
				.Include(x => x.Reservas)
				.Include(x => x.Direccion)
					.ThenInclude(direccion => direccion!.Ciudad)
					.Where(propiedad => propiedad.Direccion!.Ciudad.Id == ciudadId)
					.ToList();
			var propiedadesDisponibles = propiedades
			.Where(propiedad => propiedad.Reservas.All(reserva =>
				fechaEntrada >= reserva.FechaSalida || fechaSalida <= reserva.FechaEntrada))
			.ToList();
			return propiedadesDisponibles;
		}

		public async Task<List<Propiedad>> FindByIds(List<Guid> ids)
		{
			return await _context.Propiedad
					.Where(p => ids.Contains(p.Id))
					.ToListAsync();
		}

		public async Task<Propiedad?> FindByIdAsync(Guid id)
		{
			return await _context.Propiedad
				.Include(x => x.Capacidad)
				.Include("_comodidades")
				.Include(x => x.Direccion)
					.ThenInclude(direccion => direccion!.Ciudad)
				.Where(x => x.Id == id).AsSplitQuery().FirstOrDefaultAsync();
		}

		public Task UpdateAsync(Propiedad Propiedad)
		{
			_context.Propiedad.Update(Propiedad);
			return Task.CompletedTask;
		}

		public Task<Propiedad?> FindByReserva(Guid idReserva)
		{
			var propiedadAsociada = _context.Propiedad.FirstOrDefaultAsync(
				propiedad => propiedad.Reservas.Any(reserva => reserva.Id == idReserva));
			return propiedadAsociada;
		}

		public async Task<List<Propiedad>> FindByUsuarioId(Guid usuarioId)
		{
			return await _context.Propiedad
				.Include(x => x.Reservas)
				.Include(x => x.Direccion)
				.Where(x => x.UsuarioId == usuarioId)
					.ToListAsync();
		}
	}
}
