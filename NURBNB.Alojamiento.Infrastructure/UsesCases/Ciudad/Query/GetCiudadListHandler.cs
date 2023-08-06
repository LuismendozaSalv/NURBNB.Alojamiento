using MediatR;
using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Query;
using NURBNB.Alojamiento.Application.UseCases.Pais.Query.GetPaisList;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using NURBNB.Alojamiento.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                query = query.Where(x => x.Nombre.Contains(request.SearchTerm));
            }

            return await query.Select(pais =>
                new CiudadDto
                {
                    Id = pais.Id,
                    Nombre = pais.Nombre,
                    PaisId = pais.PaisId
                }).ToListAsync(cancellationToken);
        }
    }
}
