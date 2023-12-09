using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("regla")]
	public class ReglaReadModel
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }

		[Required]
		[Column("propiedadId")]
		public Guid PropiedadId { get; set; }

		[Column("Value")]
		[StringLength(250)]
		[Required]
		public string Value { get; set; }
	}
}
