using MediatR;
using NURBNB.Alojamiento.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Ciudad.Query
{
	public class GetCiudadQueryList : IRequest<ICollection<CiudadDto>>
	{
		public string SearchTerm { get; set; }
	}
}
