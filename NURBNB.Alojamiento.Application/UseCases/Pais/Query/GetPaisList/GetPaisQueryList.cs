using MediatR;
using NURBNB.Alojamiento.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Pais.Query.GetPaisList
{
	public class GetPaisQueryList : IRequest<ICollection<PaisDto>>
	{
		public string? SearchTerm { get; set; }
	}
}
