using MediatR;
using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Application.UseCases.Pais.Query.GetPaisList;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using NURBNB.Alojamiento.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.UsesCases.Pais.Query
{
	internal class GetPaisListHandler : IRequestHandler<GetPaisQueryList, ICollection<PaisDto>>
	{
		private readonly DbSet<PaisReadModel> _paises;

		public GetPaisListHandler(ReadDbContext context)
		{
			_paises = context.Pais;
		}
		public async Task<ICollection<PaisDto>> Handle(GetPaisQueryList request, CancellationToken cancellationToken)
		{
			var query = _paises.AsNoTracking();

			if (!string.IsNullOrWhiteSpace(request.SearchTerm))
			{
				query = query.Where(x => x.Nombre.Contains(request.SearchTerm));
			}

			return await query.Select(pais =>
				new PaisDto
				{
					Id = pais.Id,
					Nombre = pais.Nombre,
					CodigoPais = pais.CodigoPais
				}).ToListAsync(cancellationToken);
		}
	}
}
