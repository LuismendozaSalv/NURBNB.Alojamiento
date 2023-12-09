using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("foto")]
	public class FotoReadModel
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }

		[Required]
		[Column("propiedadId")]
		public Guid PropiedadId { get; set; }

		[Column("url")]
		[StringLength(250)]
		[Required]
		public string Url { get; set; }
	}
}
