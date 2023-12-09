using MediatR;
using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Query;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using NURBNB.Alojamiento.Infrastructure.EF.ReadModel;

namespace NURBNB.Alojamiento.Infrastructure.UsesCases.Ciudad.Query
{
	internal class GetCiudadListHandler : IRequestHandler<GetCiudadQueryList, ICollection<CiudadDto>>
	{
		private readonly DbSet<CiudadReadModel> _ciudades;

		public GetCiudadListHandler(ReadDbContext context)
		{
			_ciudades = context.Ciudad;
		}
		public async Task<ICollection<CiudadDto>> Handle(GetCiudadQueryList request, CancellationToken cancellationToken)
		{
			var query = _ciudades.AsNoTracking();

			if (!string.IsNullOrWhiteSpace(request.SearchTerm))
			{
				query = query.Include(x => x.Pais).Where(x => x.Nombre.Contains(request.SearchTerm));
			}

			return await query.Select(ciudad =>
				new CiudadDto
				{
					Id = ciudad.Id,
					Nombre = ciudad.Nombre,
					PaisId = ciudad.PaisId,
					NombrePais = ciudad.Pais.Nombre
				}).ToListAsync(cancellationToken);
		}
	}
}
