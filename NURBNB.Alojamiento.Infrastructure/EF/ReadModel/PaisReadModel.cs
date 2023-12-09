using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("pais")]
	public class PaisReadModel
	{
		[Key]
		[Column("paisId")]
		public Guid Id { get; set; }

		[Column("nombre")]
		[StringLength(250)]
		[Required]
		public string Nombre { get; set; }

		[Column("paisCode")]
		[StringLength(10)]
		[Required]
		public string CodigoPais { get; set; }
	}
}
